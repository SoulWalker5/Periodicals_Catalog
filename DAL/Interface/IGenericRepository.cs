using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T FindById(int id);
        IEnumerable<T> GetAll();
        void Create(T item);
        void Remove(int id);
        void Update(T item);
    }   
}
