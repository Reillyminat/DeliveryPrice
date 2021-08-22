using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore5.Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllMatchingTheFilter(Predicate<string> predicate);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
