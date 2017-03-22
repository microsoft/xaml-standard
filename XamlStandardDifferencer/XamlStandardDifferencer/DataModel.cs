using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XamlStandardDifferencer
{
    public enum Platform
    {
        UXPXaml,
        XamarinForms
    }

    public class PropertyDescription
    {
        public PropertyDescription(TypeDescription parent, PropertyInfo property, TypeFactory typeFactory)
        {
            this.Parent = parent;
            this.Name = property.Name;
            this.Type = typeFactory.GetType(property.PropertyType, parent.Platform);
            HasGetter = (property.GetGetMethod() != null);
            HasSetter = (property.GetSetMethod() != null);
        }

        public TypeDescription Parent
        {
            get;
            private set;
        }

        public String Name
        {
            get;
            private set;
        }

        public TypeDescription Type
        {
            get;
            private set;
        }

        public bool HasSetter
        {
            get;
            private set;
        }

        public bool HasGetter
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", Name, Type.Name);
        }
    }

    public class PropertyCollection : IEnumerable<PropertyDescription>
    {
        private List<PropertyDescription> _properties = new List<PropertyDescription>();
        private Dictionary<String, PropertyDescription> _propertiesByName = new Dictionary<String, PropertyDescription>(StringComparer.InvariantCultureIgnoreCase);

        public PropertyCollection()
        {
        }

        public PropertyCollection(IEnumerable<PropertyDescription> copy)
        {
            Add(copy);
        }

        public IEnumerator<PropertyDescription> GetEnumerator()
        {
            return new List<PropertyDescription>(_properties).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new List<PropertyDescription>(_properties).GetEnumerator();
        }

        public int Count
        {
            get
            {
                return _properties.Count;
            }
        }

        public PropertyDescription this[int ix]
        {
            get
            {
                return _properties[ix];
            }
        }

        public void Add(PropertyDescription property)
        {
            _properties.Add(property);
            _propertiesByName[property.Name] = property;
        }

        public void Add(IEnumerable<PropertyDescription> properties)
        {
            foreach (PropertyDescription property in properties)
            {
                Add(property);
            }
        }

        public void Remove(PropertyDescription property)
        {
            _properties.Remove(property);
            _propertiesByName.Remove(property.Name);
        }

        public PropertyDescription GetPropertyByName(String name)
        {
            PropertyDescription type = null;
            _propertiesByName.TryGetValue(name, out type);
            return type;
        }
    }

    public class TypeDescription
    {
        public TypeDescription(Type type, Platform platform)
        {
            Namespace = type.Namespace;

            if (type.FullName != null)
            {
                // Use the FullName if available - this will include the outer class of a nested type (Name does not).
                Name = type.FullName.Substring(this.Namespace.Length + 1);
            }
            else
            {
                // FullName may not be avialable - e.g. a generic parameter. Use Name instead.
                Name = type.Name;
            }

            this.Platform = platform;

            // handle nested types
            Name = Name.Replace('+', '.');
        }

        public void Resolve(Type type, TypeFactory typeFactory)
        {
            if (type.IsGenericType)
            {
                ResolveGenericArguments(type, typeFactory);
            }
            ResolveParent(type, typeFactory);
            ResolveProperties(type, typeFactory);
        }

        private void ResolveParent(Type type, TypeFactory typeFactory)
        {
            if (!type.IsInterface &&
                typeof(object) != type &&
                typeof(object) != type.BaseType &&
                type.BaseType.FullName != "System.Runtime.InteropServices.WindowsRuntime.RuntimeClass")
            {
                this.Parent = typeFactory.GetType(type.BaseType, this.Platform);
            }
        }

        private void ResolveProperties(Type type, TypeFactory typeFactory)
        {
            this.Properties = new PropertyCollection();
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                this.Properties.Add(new PropertyDescription(this, property, typeFactory));
            }
        }

        private void ResolveGenericArguments(Type type, TypeFactory typeFactory)
        {
            Type[] genericArguments = type.GetGenericArguments();
            int currentGenericIx = 0;

            StringBuilder newName = new StringBuilder();
            for (int nameIx = 0; nameIx < Name.Length; ++nameIx)
            {
                if (Name[nameIx] == '`')
                {
                    // parse out the number of generic args
                    StringBuilder countString = new StringBuilder();
                    while (nameIx + 1 < Name.Length && Char.IsDigit(Name[nameIx + 1]))
                    {
                        countString.Append(Name[nameIx + 1]);
                        ++nameIx;
                    }
                    int count = Int32.Parse(countString.ToString());

                    newName.Append('<');
                    for (int i = 0; i < count; ++i)
                    {
                        if (currentGenericIx < genericArguments.Length)
                        {
                            TypeDescription genericTypeArgDescription = typeFactory.GetType(genericArguments[currentGenericIx++], Platform);
                            newName.Append(genericTypeArgDescription.Name);
                        }
                        else
                        {
                            newName.Append("???");
                        }
                        if (i < count - 1)
                        {
                            newName.Append(',');
                        }
                    }
                    newName.Append('>');
                }
                else
                {
                    newName.Append(Name[nameIx]);
                }
            }

            this.Name = newName.ToString();
        }

        public String Namespace
        {
            get;
            private set;
        }

        public String Name
        {
            get;
            private set;
        }

        public Platform Platform
        {
            get;
            private set;
        }

        public TypeDescription Parent
        {
            get;
            private set;
        }

        public PropertyCollection Properties
        {
            get;
            private set;
        }

        public PropertyDescription GetPropertyByName(String name)
        {
            foreach (PropertyDescription property in Properties)
            {
                if (property.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return property;
                }
            }
            return null;
        }

        public String FullName
        {
            get
            {
                return String.Format("{0}.{1}", Namespace, Name);
            }
        }

        public override string ToString()
        {
            return String.Format("{0}.{1} ({2})", Namespace, Name, Platform);
        }

        public bool IsInterestingForXamlStandard()
        {
            if (Platform.XamarinForms == Platform)
            {
                if (Namespace.StartsWith("Xamarin.Forms.Internals", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
                if (Namespace.StartsWith("Xamarin.Forms.PlatformConfiguration", StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }
    }

    // Ensures that there is a only a single TypeDescription instance for a given type.
    // This single-instancing is needed when references between types are circular.
    public class TypeFactory
    {
        private TypeCollection _allTypes = new TypeCollection();

        public TypeDescription GetType(Type inputType, Platform platform)
        {
            // Currently, generic parameters are not single-instanced by the factory. They don't have a full name, so
            // the current mapping of full name to TypeDescription can't be used for them.
            if (inputType.IsGenericParameter)
            {
                TypeDescription genericParameterType = new TypeDescription(inputType, platform);
                genericParameterType.Resolve(inputType, this);
                return genericParameterType;
            }

            if (inputType.FullName == null)
            {
                // When FullName is non-null, it can be used to uniquely identify a type.
                // When null, we return a TypeDescription but don't try to single-instance it.
                // The most common case is a generic type that is not the definition of that generic type
                // (i.e. one or more generic parameters are bound).
                // See: https://blogs.msdn.microsoft.com/haibo_luo/2006/02/17/type-fullname-returns-null-when/
                TypeDescription nonCachedType = new TypeDescription(inputType, platform);
                nonCachedType.Resolve(inputType, this);
                return nonCachedType;
            }

            TypeDescription type = _allTypes.GetTypeByFullName(inputType.FullName);
            if (type == null)
            {
                type = new TypeDescription(inputType, platform);
                _allTypes.Add(type);
                type.Resolve(inputType, this);
            }
            return type;
        }
    }

    public class TypeCollection : IEnumerable<TypeDescription>
    {
        private List<TypeDescription> _types = new List<TypeDescription>();
        private Dictionary<String, TypeDescription> _typesByFullName = new Dictionary<String, TypeDescription>(StringComparer.InvariantCultureIgnoreCase);

        public TypeCollection()
        {
        }

        public TypeCollection(IEnumerable<TypeDescription> copy)
        {
            foreach (TypeDescription type in copy)
            {
                Add(type);
            }
        }

        public IEnumerator<TypeDescription> GetEnumerator()
        {
            return new List<TypeDescription>(_types).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new List<TypeDescription>(_types).GetEnumerator();
        }

        public int Count
        {
            get
            {
                return _types.Count;
            }
        }

        public TypeDescription this[int ix]
        {
            get
            {
                return _types[ix];
            }
        }

        public void Add(TypeDescription type)
        {
            _types.Add(type);
            _typesByFullName[type.FullName] = type;
        }

        public void Remove(TypeDescription type)
        {
            _types.Remove(type);
            _typesByFullName.Remove(type.FullName);
        }

        public TypeDescription GetTypeByFullName(String fullName)
        {
            TypeDescription type = null;
            _typesByFullName.TryGetValue(fullName, out type);
            return type;
        }

        public TypeCollection GetTypesWithName(String name)
        {
            TypeCollection result = new TypeCollection();
            foreach (TypeDescription type in _types)
            {
                if (type.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Add(type);
                }
            }
            return result;
        }

        public void RemoveTypesUnderNamespace(String ns)
        {
            foreach (TypeDescription type in this)
            {
                if (type.Namespace.StartsWith(ns, StringComparison.InvariantCultureIgnoreCase))
                {
                    Remove(type);
                }
            }
        }

        public TypeCollection GetTypesThatAreInterestingForXamlStandard()
        {
            TypeCollection result = new TypeCollection();
            foreach (TypeDescription type in _types)
            {
                if (type.IsInterestingForXamlStandard())
                {
                    result.Add(type);
                }
            }
            return result;
        }
    }
}
