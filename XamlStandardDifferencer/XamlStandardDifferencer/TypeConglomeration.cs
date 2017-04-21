using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlStandardDifferencer
{
    public class TypeConglomeration
    {
        public TypeConglomeration()
        {
            Types = new List<TypeDescription>();
        }

        public List<TypeDescription> Types
        {
            get;
            private set;
        }

        public PropertyCollection GetAllProperties()
        {
            PropertyCollection result = new PropertyCollection();
            foreach (TypeDescription type in Types)
            {
                result.Add(type.Properties);
            }
            return result;
        }
    }
}
