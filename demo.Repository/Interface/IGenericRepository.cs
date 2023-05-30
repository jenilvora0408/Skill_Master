using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demo.Repository.Interface
{
    public interface IGenericRepository<T>
    {
        public void Add(T entity);

        public void Update(T entity);

        public void Remove(T entity);

        public List<T> List(Expression<Func<T, bool>> condition);

        public T FirstData(Expression<Func<T, bool>> condition);

        public T DefaultData(Expression<Func<T, bool>> condition);

        public IQueryable<T> QueryableData(Expression<Func<T, bool>> condition);

        public bool AnyData(Expression<Func<T, bool>> condition);
    }
}
