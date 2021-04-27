using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel
{
    public class ImplementationsContainer
    {
        private IDictionary<Type, object> implementations = new Dictionary<Type, object>();

        public TImplementation Get<TImplementation>()
        {
            return (TImplementation)this[typeof(TImplementation)];
        }

        public void Set<TImplementation>(TImplementation instance)
        {
            this[typeof(TImplementation)] = instance;
        }

        public object this[Type key]
        {
            get
            {
                if (key == null)
                    throw new ArgumentNullException(nameof(key));
                return implementations != null && implementations.TryGetValue(key, out var result) ? result : default;
            }
            set
            {
                if(key==null)
                    throw new ArgumentNullException(nameof(key));
                if (value == null)
                {
                    if (implementations != null)
                    {
                        implementations.Remove(key);
                    }
                    return;
                }

                implementations[key] = value;
            }
        }
    }
}
