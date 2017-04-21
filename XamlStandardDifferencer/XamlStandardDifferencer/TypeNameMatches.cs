using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlStandardDifferencer
{
    public class TypeNameMatches
    {
        public TypeNameMatches(TypeCollection first, TypeCollection second)
        {
            this.MatchedTypes = new List<KeyValuePair<TypeDescription, TypeDescription>>();

            Dictionary<String, List<TypeDescription>> firstTypesByNames = IndexTypesByNames(first);
            Dictionary<String, List<TypeDescription>> secondTypesByNames = IndexTypesByNames(second);

            foreach (KeyValuePair<String, List<TypeDescription>> pair in firstTypesByNames)
            {
                if (pair.Value.Count > 1)
                {
                    continue;
                }

                List<TypeDescription> secondTypesListForName = null;
                secondTypesByNames.TryGetValue(pair.Key, out secondTypesListForName);
                if (secondTypesListForName != null && secondTypesListForName.Count == 1)
                {
                    MatchedTypes.Add(new KeyValuePair<TypeDescription, TypeDescription>(pair.Value[0], secondTypesListForName[0]));
                }
            }
        }

        private Dictionary<String, List<TypeDescription>> IndexTypesByNames(TypeCollection types)
        {
            Dictionary<String, List<TypeDescription>> result = new Dictionary<String, List<TypeDescription>>(StringComparer.InvariantCultureIgnoreCase);
            foreach (TypeDescription type in types)
            {
                List<TypeDescription> typesForName;
                if (!result.TryGetValue(type.Name, out typesForName))
                {
                    typesForName = new List<TypeDescription>();
                    result.Add(type.Name, typesForName);
                }
                typesForName.Add(type);
            }
            return result;
        }

        public List<KeyValuePair<TypeDescription, TypeDescription>> MatchedTypes
        {
            get;
            private set;
        }

    }
}
