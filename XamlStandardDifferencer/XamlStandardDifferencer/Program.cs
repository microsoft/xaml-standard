using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace XamlStandardDifferencer
{
    public class Foo<TOne, TTwo>
    {
        public class Bar<TThree, TFour>
        {
            public TOne MyProp
            {
                get;
                private set;
            }
        }
    }

    public class HierarchyCallback : ICompareHierarchyCallback
    {
        public bool ShouldCompareType(TypeDescription typeBeingCompared, TypeDescription typeAncestor)
        {
            if (typeBeingCompared.Platform == Platform.UXPXaml)
            {
                if (typeAncestor.FullName.Equals("Windows.UI.Xaml.Controls.ContentControl", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                if (typeAncestor.FullName.Equals("Windows.UI.Xaml.Controls.Control", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                if (typeAncestor.FullName.Equals("Windows.UI.Xaml.FrameworkElement", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                if (typeAncestor.FullName.Equals("Windows.UI.Xaml.UIElement", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                if (typeAncestor.FullName.Equals("Windows.UI.Xaml.DependencyObject", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                return true;
            }
            else if (typeBeingCompared.Platform == Platform.XamarinForms)
            {
                if (typeAncestor.FullName.Equals("Xamarin.Forms.View", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                if (typeAncestor.FullName.Equals("Xamarin.Forms.VisualElement", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                if (typeAncestor.FullName.Equals("Xamarin.Forms.Element", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                return true;
            }
            else
            {
                throw new Exception("unhandled platform");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TypeFactory typeFactory = new TypeFactory();

            /*
            TypeDescription test1 = typeFactory.GetType(typeof(Foo<,>), Platform.UXPXaml);
            TypeDescription test2 = typeFactory.GetType(typeof(Foo<,>.Bar<,>), Platform.UXPXaml);
            return;
            */

            TypeCollection uwpXamlTypes = TypeReflector.GetUWPXamlTypes(typeFactory);
            TypeCollection xamarinFormsTypes = TypeReflector.GetXamarinFormsTypes(typeFactory);

            TypeNameMatches typeNameMatches = new TypeNameMatches(uwpXamlTypes.GetTypesThatAreInterestingForXamlStandard(), xamarinFormsTypes.GetTypesThatAreInterestingForXamlStandard());

            TypeNameMappingList typeMapping = new TypeNameMappingList();

            typeMapping.Add(TypeNameMappingList.UXPXamlToXamarinFormsMappings);
            typeMapping.Add(TypeNameMappingList.DotNetEquivalentMappings);
            typeMapping.Add(typeNameMatches.MatchedTypes);

            TypeEquivalentCollection typeEquivalency = new TypeEquivalentCollection(
                uwpXamlTypes,
                xamarinFormsTypes,
                typeMapping);

            HtmlWriter writer = new HtmlWriter(@"c:\temp\xaml_standard.html");

            writer.WriteHeader2("Corresponding Types");
            writer.BeginTable(true);
            writer.BeginTableRow();
            writer.WriteTableHeader("UWP Xaml Type");
            writer.WriteTableHeader("Xamarin Forms Type");
            writer.WriteTableHeader("Properties in both");
            writer.WriteTableHeader("Properties only in UWP Xaml");
            writer.WriteTableHeader("Properties only in Xamarin Forms");
            writer.EndTableRow();

            CSVWriter csvWriter = new CSVWriter(@"c:\temp\equivalent_types.csv");
            csvWriter.AddRow("UWP Xaml Type", "Xamarin Forms Type");

            HierarchyCallback hierarchyCallback = new HierarchyCallback();
            foreach (KeyValuePair<TypeDescription, TypeDescription> pair in typeEquivalency.MatchedTypes)
            {
                writer.BeginTableRow();
                writer.WriteTableData(pair.Key.FullName);
                writer.WriteTableData(pair.Value.FullName);

                TypeDelta delta = new TypeDelta(pair.Key, pair.Value, typeMapping, hierarchyCallback);
                WriteProperties(writer, pair.Key, pair.Value, delta.PropertiesDelta.PropertiesInBoth);
                WriteProperties(writer, pair.Key, delta.PropertiesDelta.PropertiesOnlyInFirst);
                WriteProperties(writer, pair.Value, delta.PropertiesDelta.PropertiesOnlyInSecond);

                writer.EndTableRow();

                csvWriter.AddRow(pair.Key.FullName, pair.Value.FullName);
            }
            writer.EndTable();
            csvWriter.Close();

            WriteBaseTypesComparison(writer, uwpXamlTypes, xamarinFormsTypes, typeMapping);

            WriteTypes(writer, "Unmatched Types: Xamarin Forms", xamarinFormsTypes.GetTypesThatAreInterestingForXamlStandard());
            WriteTypes(writer, "Unmatched Types: UWP Xaml", uwpXamlTypes.GetTypesThatAreInterestingForXamlStandard());

            writer.Close();
        }

        static void WriteBaseTypesComparison(HtmlWriter writer, TypeCollection uwpXamlTypes, TypeCollection xamarinFormsTypes, TypeNameMappingList typeMapping)
        {
            List<KeyValuePair<TypeConglomeration, TypeConglomeration>> data = new List<KeyValuePair<TypeConglomeration, TypeConglomeration>>();

            TypeConglomeration uwpElement = new TypeConglomeration();
            uwpElement.Types.Add(uwpXamlTypes.GetTypeByFullName("Windows.UI.Xaml.FrameworkElement"));
            uwpElement.Types.Add(uwpXamlTypes.GetTypeByFullName("Windows.UI.Xaml.UIElement"));

            TypeConglomeration xamarinElement = new TypeConglomeration();
            xamarinElement.Types.Add(xamarinFormsTypes.GetTypeByFullName("Xamarin.Forms.Element"));
            xamarinElement.Types.Add(xamarinFormsTypes.GetTypeByFullName("Xamarin.Forms.VisualElement"));

            data.Add(new KeyValuePair<TypeConglomeration, TypeConglomeration>(uwpElement, xamarinElement));

            writer.WriteHeader2("Base Types Comparison");
            writer.BeginTable(true);
            writer.BeginTableRow();
            writer.WriteTableHeader("UWP Xaml");
            writer.WriteTableHeader("Xamarin Forms");
            writer.WriteTableHeader("Properties in both");
            writer.WriteTableHeader("Properties only in UWP Xaml");
            writer.WriteTableHeader("Properties only in Xamarin Forms");
            writer.EndTableRow();

            foreach (KeyValuePair<TypeConglomeration, TypeConglomeration> pair in data)
            {
                PropertiesDelta delta = new PropertiesDelta(pair.Key.GetAllProperties(), pair.Value.GetAllProperties(), typeMapping);

                writer.BeginTableRow();

                writer.BeginTableData();
                foreach (TypeDescription type in pair.Key.Types)
                {
                    writer.WriteText(type.FullName);
                    writer.WriteLineBreak();
                }
                writer.EndTableData();

                writer.BeginTableData();
                foreach (TypeDescription type in pair.Value.Types)
                {
                    writer.WriteText(type.FullName);
                    writer.WriteLineBreak();
                }
                writer.EndTableData();

                WriteProperties(writer, null, null, delta.PropertiesInBoth);
                WriteProperties(writer, null, delta.PropertiesOnlyInFirst);
                WriteProperties(writer, null, delta.PropertiesOnlyInSecond);

                writer.EndTableRow();
            }

            writer.EndTable();
        }

        static void WriteProperties(HtmlWriter writer, TypeDescription firstType, TypeDescription secondType, IEnumerable<KeyValuePair<PropertyDescription, PropertyDescription>> properties)
        {
            writer.BeginTableData();
            foreach (KeyValuePair<PropertyDescription, PropertyDescription> pair in properties)
            {
                String firstPropertyDescription;
                if (firstType == null || pair.Key.Parent != firstType)
                {
                    firstPropertyDescription = String.Format("{0}.{1} ({2})", pair.Key.Parent.Name, pair.Key.Name, pair.Key.Type.Name);
                }
                else
                {
                    firstPropertyDescription = String.Format("{0} ({1})", pair.Key.Name, pair.Key.Type.Name);
                }

                String secondPropertyDescription;
                if (secondType == null || pair.Value.Parent != secondType)
                {
                    secondPropertyDescription = String.Format("{0}.{1} ({2})", pair.Value.Parent.Name, pair.Value.Name, pair.Value.Type.Name);
                }
                else
                {
                    secondPropertyDescription = String.Format("{0} ({1})", pair.Value.Name, pair.Value.Type.Name);
                }

                writer.WriteText(String.Format("{0} = {1}", firstPropertyDescription, secondPropertyDescription));
                writer.WriteLineBreak();
            }
            writer.EndTableData();
        }

        static void WriteProperties(HtmlWriter writer, TypeDescription typeBeingCompared, IEnumerable<PropertyDescription> properties)
        {
            writer.BeginTableData();
            foreach (PropertyDescription property in properties)
            {
                if (typeBeingCompared == null || property.Parent != typeBeingCompared)
                {
                    writer.WriteText(String.Format("{0}.{1} ({2})", property.Parent.Name, property.Name, property.Type.Name));
                }
                else
                {
                    writer.WriteText(String.Format("{0} ({1})", property.Name, property.Type.Name));
                }
                writer.WriteLineBreak();
            }
            writer.EndTableData();
        }

        static void WriteTypes(HtmlWriter writer, String label, TypeCollection types)
        {
            writer.WriteHeader2(String.Format("{0} ({1})", label, types.Count));
            writer.BeginPre();
            foreach (TypeDescription type in types)
            {
                if (type.Parent != null)
                {
                    writer.WriteText(String.Format("{0} ({1})", type.FullName, type.Parent.FullName));
                }
                else
                {
                    writer.WriteText(type.FullName);
                }
            }
            writer.EndPre();
        }
    }
}
