using System;

namespace AppliancesModel.Contracts
{
    public interface ICacheable
    {
        T GetObject<T>(Action callback) where T : class;
        void SetInstance(object instance);
    }
}
