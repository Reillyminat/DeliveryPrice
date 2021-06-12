using AppliancesModel.Contracts;
using System;
using System.Threading;

namespace AppliancesModel.Models
{
    public class Cache : ICacheable
    {
        private readonly object data;

        private object copy;

        private bool obsoleteCopy;

        private object locker = new object();

        public Cache(object instance)
        {
            data = instance;
            obsoleteCopy = true;
        }

        public T GetObject<T>(Action callback) where T : class
        {
            lock (locker)
            {
                if (obsoleteCopy)
                {
                    var dataTimeExistance = 100000;
                    var thread = new Thread(o =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        Thread.Sleep(dataTimeExistance);
                        obsoleteCopy = true;
                    });
                    thread.Start();
                    copy = JsonSerialization.CreateDeepCopy((T)data);
                    obsoleteCopy = false;
                }

                callback.Invoke();

                return (T)copy;
            }
        }
    }
}
