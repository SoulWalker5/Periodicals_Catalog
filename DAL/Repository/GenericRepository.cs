using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PeriodicalsContext _ctx;
        public GenericRepository()
        {
            _ctx = new PeriodicalsContext();
        }
        public void Create(T item)
        {
            _ctx.Set<T>().Add(item);
            _ctx.SaveChanges();
        }

        public T FindById(int id)
        {
            var search = _ctx.Set<T>().Find(id);

            return search;
        }

        public IEnumerable<T> GetAll()
        {
            var searachRes = _ctx.Set<T>();
            //var searachRes = _ctx.Set<T>().AsNoTracking().ToList();

            return searachRes;
        }

        public void Remove(int id)
        {
            var tEntity = _ctx.Set<T>().Find(id);
            _ctx.Set<T>().Remove(tEntity);
            _ctx.SaveChanges();
        }

        public void Update(T item)
        {
            _ctx.Set<T>().AddOrUpdate(item);
            _ctx.SaveChanges();
        }
    }
}
