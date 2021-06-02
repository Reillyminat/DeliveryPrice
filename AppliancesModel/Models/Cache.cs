using AppliancesModel.Contracts;
using System.Threading;

namespace AppliancesModel.Models
{
    public class Cache : ICacheable
    {
        private object data;

        private object copy;

        private object locker = new object();

        public Cache(object instance)
        {
            data = instance;
            copy = null;
        }

        public void AddObject()
        {

        }

        public T GetObject<T>()
        {
            if (copy == null)
            {
                lock (locker)
                {
                    copy = JsonSerialization.CreateDeepCopy((T)data);
                }
                var thread = new Thread(o =>
                {
                    Thread.Sleep(10000);
                    copy = null;
                });
            }
            return (T)copy;
        }
    }
}
