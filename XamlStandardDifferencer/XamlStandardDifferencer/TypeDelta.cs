using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlStandardDifferencer
{
    public interface ICompareHierarchyCallback
    {
        // Called when comparing typeBeingCompared to another type.
        // The comparison can include some of the members from typeBeingCompared's ancestor hierarchy.
        // This function decides whether an ancestor type is a stopping point or not.
        // Return true means include this ancestor type's members in the comparison, and keep going up the hierarchy.
        // Return false means do not include this ancestor type's members in the comparison, and stop going up the hierarchy.
        bool ShouldCompareType(TypeDescription typeBeingCompared, TypeDescription typeAncestor);
    }

    public class PropertiesDelta
    {
        public PropertiesDelta(
            PropertyCollection first,
            PropertyCollection second,
            TypeNameMappingList typeMapping)
        {
            CalculatePropertyDeltas(first, second, typeMapping);
        }

        public PropertyCollection PropertiesOnlyInFirst
        {
            get;
            private set;
        }

        public PropertyCollection PropertiesOnlyInSecond
        {
            get;
            private set;
        }

        public List<KeyValuePair<PropertyDescription, PropertyDescription>> PropertiesInBoth
        {
            get;
            private set;
        }

        private void CalculatePropertyDeltas(PropertyCollection first, PropertyCollection second, TypeNameMappingList typeMapping)
        {
            PropertiesOnlyInFirst = new PropertyCollection();
            PropertiesOnlyInSecond = new PropertyCollection();
            PropertiesInBoth = new List<KeyValuePair<PropertyDescription, PropertyDescription>>();

            PropertiesOnlyInSecond.Add(second);

            foreach (PropertyDescription property in first)
            {
                PropertyDescription candidate = second.GetPropertyByName(property.Name);

                if (candidate != null)
                {
                    if (property.HasSetter != candidate.HasSetter)
                    {
                        candidate = null;
                    }
                }

                if (candidate != null)
                {
                    if (property.HasGetter != candidate.HasGetter)
                    {
                        candidate = null;
                    }
                }

                if (candidate != null)
                {
                    if (!typeMapping.AreEquivalent(property.Type, candidate.Type))
                    {
                        candidate = null;
                    }
                }

                if (candidate == null)
                {
                    PropertiesOnlyInFirst.Add(property);
                }
                else
                {
                    PropertiesOnlyInSecond.Remove(candidate);
                    PropertiesInBoth.Add(new KeyValuePair<PropertyDescription, PropertyDescription>(property, candidate));
                }
            }
        }
    }

    public class TypeDelta
    {
        public TypeDelta(
            TypeDescription first, 
            TypeDescription second, 
            TypeNameMappingList typeMapping,
            ICompareHierarchyCallback hierarchyCallback)
        {
            this.First = first;
            this.Second = second;

            // Determine the full set of properties to look at.
            PropertyCollection firstProperties = DetermineFullSetOfPropertiesToCompare(First, hierarchyCallback);
            PropertyCollection secondProperties = DetermineFullSetOfPropertiesToCompare(Second, hierarchyCallback);

            this.PropertiesDelta = new PropertiesDelta(firstProperties, secondProperties, typeMapping);
        }

        public TypeDescription First
        {
            get;
            private set;
        }

        public TypeDescription Second
        {
            get;
            private set;
        }

        public PropertiesDelta PropertiesDelta
        {
            get;
            private set;
        }

        private PropertyCollection DetermineFullSetOfPropertiesToCompare(TypeDescription type, ICompareHierarchyCallback hierarchyCallback)
        {
            PropertyCollection properties = new PropertyCollection();
            properties.Add(type.Properties);
            TypeDescription ancestor = type.Parent;
            while (ancestor != null && hierarchyCallback.ShouldCompareType(type, ancestor))
            {
                properties.Add(ancestor.Properties);
                ancestor = ancestor.Parent;
            }
            return properties;
        }
    }
}
