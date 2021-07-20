using System.Collections;
using System.Collections.Generic;

namespace DeliveryServiceModel
{
    public class Suppliers:IEnumerable
    {
        public ICollection<Supplier> SuppliersCollection { get; set; }

        public Suppliers()
        {
            SuppliersCollection = new List<Supplier>();
        }
        public IEnumerator GetEnumerator()
        {
            return SuppliersCollection.GetEnumerator();
        }

        public void Add(Supplier supplier)
        {
            SuppliersCollection.Add(supplier);
        }
    }
}
