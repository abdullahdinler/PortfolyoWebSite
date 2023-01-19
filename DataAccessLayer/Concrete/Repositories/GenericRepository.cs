using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private Context context = new Context();
        private DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }
        public List<T> List()
        {
             return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> Fiter)
        {

            return _object.Where(Fiter).ToList();
        }

        public void Add(T entity)
        {
            var AddedEntity = context.Entry(entity);
            AddedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            var DeletedEntity = context.Entry(entity);
            DeletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            var UpdatedEntity = context.Entry(entity);
            UpdatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }
    }
}
