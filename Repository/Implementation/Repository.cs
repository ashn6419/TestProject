using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext db;
        public Repository(DbContext _db)
        {
            db = _db;
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int Id)
        {
            return db.Set<TEntity>().Find(Id);
        }

        public void Update(TEntity entity)
        {
            db.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
