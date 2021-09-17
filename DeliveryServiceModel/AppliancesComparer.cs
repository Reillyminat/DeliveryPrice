using System.Collections.Generic;

namespace DeliveryServiceModel
{
    public class AppliancesComparer : IEqualityComparer<Product>, IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return x.Name.CompareTo(y.Name);
        }

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
