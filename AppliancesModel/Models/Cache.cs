using AppliancesModel.Contracts;
using System;

namespace AppliancesModel.Models
{
    public class Cache : ICacheable
    {
        private readonly object data;

        private object copy;

        private DateTime copyCreation;

        private object locker = new object();

        public Cache(object instance)
        {
            data = instance;
        }

        public T GetObject<T>(Action callback) where T : class
        {
            lock (locker)
            {
                if (DateTime.Now > copyCreation.AddSeconds(600))
                {
                    copyCreation = DateTime.Now;
                    copy = JsonSerialization.CreateDeepCopy((T)data);
                }


                callback.Invoke();

                return (T)copy;
            }
        }
    }
}
