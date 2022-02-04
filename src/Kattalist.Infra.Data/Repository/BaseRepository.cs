using Kattalist.Domain.Entities;
using Kattalist.Domain.Interfaces;
using Kattalist.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kattalist.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly KattalistDbContext _kattalistDbContext;

        public BaseRepository(KattalistDbContext kattalistDbContext)
        {
            _kattalistDbContext = kattalistDbContext;
        }
        public void Delete(int id)
        {
            _kattalistDbContext.Set<T>().Remove(Select(id));
            _kattalistDbContext.SaveChanges();
        }

        public void Insert(T obj)
        {
            try
            {
                _kattalistDbContext.Set<T>().Add(obj);
                _kattalistDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IList<T> Select()
        {
            return _kattalistDbContext.Set<T>().ToList();
        }

        public T Select(int id)
        {
            return _kattalistDbContext.Set<T>().Find(id);
            
        }

        public void Update(T obj)
        {
            _kattalistDbContext.Entry(obj).State = Microsoft.EntityFrameworkCore
                .EntityState.Modified;
            _kattalistDbContext.SaveChanges();

        }
    }
}
