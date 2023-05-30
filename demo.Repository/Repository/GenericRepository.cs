using demo.Entities.Data;
using demo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demo.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DemoContext _context;

        public GenericRepository(DemoContext context)
        {
            this._context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition).ToList();
        }

        public T FirstData(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition).First();
        }

        public T DefaultData(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().FirstOrDefault(condition);
        }

        public IQueryable<T> QueryableData(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition).AsQueryable();
        }

        public bool AnyData(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Any(condition);
        }
    }
}
