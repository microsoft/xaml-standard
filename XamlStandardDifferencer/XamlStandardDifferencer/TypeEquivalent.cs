using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlStandardDifferencer
{
    public class TypeEquivalentCollection
    {
        public TypeEquivalentCollection(TypeCollection first, TypeCollection second, TypeNameMappingList typeNameMappings)
        {
            this.MatchedTypes = new List<KeyValuePair<TypeDescription, TypeDescription>>();
            this.UnmatchedTypesFirst = new TypeCollection();
            this.UnmatchedTypesSecond = new TypeCollection(second);

            foreach (TypeDescription type in first)
            {
                TypeDescription mappedType = FindMappedType(type, second, typeNameMappings);
                if (mappedType == null)
                {
                    UnmatchedTypesFirst.Add(type);
                }
                else
                {
                    UnmatchedTypesSecond.Remove(mappedType);
                    MatchedTypes.Add(new KeyValuePair<TypeDescription, TypeDescription>(type, mappedType));
                }
            }
        }

        public List<KeyValuePair<TypeDescription, TypeDescription>> MatchedTypes
        {
            get;
            private set;
        }

        public TypeCollection UnmatchedTypesFirst
        {
            get;
            private set;
        }

        public TypeCollection UnmatchedTypesSecond
        {
            get;
            private set;
        }

        private static TypeDescription FindMappedType(TypeDescription type, TypeCollection candidates, TypeNameMappingList typeNameMappings)
        {
            String mappedTypeName = typeNameMappings.GetMappedTypeName(type.FullName);
            if (mappedTypeName != null)
            {
                return candidates.GetTypeByFullName(mappedTypeName);
            }
            return null;
        }
    }
}
