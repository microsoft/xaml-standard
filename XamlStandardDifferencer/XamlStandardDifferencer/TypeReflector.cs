using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace XamlStandardDifferencer
{
    public static class TypeReflector
    {
        static TypeReflector()
        {
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += OnReflectionOnlyAssemblyResolve;

            WindowsRuntimeMetadata.ReflectionOnlyNamespaceResolve += OnReflectionOnlyNamespaceResolve;
        }

        public static TypeCollection GetUWPXamlTypes(TypeFactory typeFactory)
        {
            Assembly assembly = Assembly.ReflectionOnlyLoadFrom(@"C:\Program Files (x86)\Windows Kits\10\References\Windows.Foundation.UniversalApiContract\2.0.0.0\Windows.Foundation.UniversalApiContract.winmd");

            TypeCollection types = new TypeCollection();
            foreach (Type type in assembly.GetExportedTypes())
            {
                if (type.Namespace.StartsWith("Windows.UI.Xaml"))
                {
                    types.Add(typeFactory.GetType(type, Platform.UXPXaml));
                }
            }
            return types;
        }

        public static TypeCollection GetXamarinFormsTypes(TypeFactory typeFactory)
        {
            TypeCollection types = new TypeCollection();

            Assembly assembly = Assembly.ReflectionOnlyLoadFrom(@"c:\temp\xamarin\Xamarin.Forms.Core.dll");
            foreach (Type type in assembly.GetExportedTypes())
            {
                types.Add(typeFactory.GetType(type, Platform.XamarinForms));
            }

            assembly = Assembly.ReflectionOnlyLoadFrom(@"c:\temp\xamarin\Xamarin.Forms.Platform.dll");
            foreach (Type type in assembly.GetExportedTypes())
            {
                types.Add(typeFactory.GetType(type, Platform.XamarinForms));
            }

            assembly = Assembly.ReflectionOnlyLoadFrom(@"c:\temp\xamarin\Xamarin.Forms.Xaml.dll");
            foreach (Type type in assembly.GetExportedTypes())
            {

                types.Add(typeFactory.GetType(type, Platform.XamarinForms));
            }

            return types;
        }

        private static void OnReflectionOnlyNamespaceResolve(object sender, NamespaceResolveEventArgs e)
        {
            IEnumerable<String> paths = WindowsRuntimeMetadata.ResolveNamespace(e.NamespaceName, new String[] { });
            String path = paths.FirstOrDefault();
            if (path == null)
            {
                return;
            }
            Assembly assembly = Assembly.ReflectionOnlyLoadFrom(path);
            e.ResolvedAssemblies.Add(assembly);
        }

        private static Assembly OnReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs e)
        {
            Assembly assembly = Assembly.ReflectionOnlyLoad(e.Name);
            return assembly;
        }
    }
}
