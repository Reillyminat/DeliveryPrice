using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceModel
{
    public class AppliancesComparer : IEqualityComparer<Appliance>
    {
        public bool Equals(Appliance x, Appliance y)
        {
            if (x.Name == y.Name&&x.Type==y.Type)
                return true;
            else
                return false;
        }

        public int GetHashCode(Appliance obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
