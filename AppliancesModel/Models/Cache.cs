using AppliancesModel.Contracts;
using System;

namespace AppliancesModel.Models
{
    public class Cache : ICacheable
    {
        private object data;

        private object copy;

        private DateTime copyCreation;

        private object locker = new object();

        public Cache() { }

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

        public void SetInstance(object instance)
        {
            data = instance;
        }
    }
}