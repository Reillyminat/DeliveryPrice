using System.Collections.Generic;

namespace DeliveryServiceModel
{
    public class AppliancesComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (x.Name == y.Name && x.CategoryId == y.CategoryId)
                return true;
            else
                return false;
        }

        public int GetHashCode(Product obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
