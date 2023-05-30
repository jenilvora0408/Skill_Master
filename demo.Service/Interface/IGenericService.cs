using demo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demo.Service.Interface
{
    public interface IGenericService<T>
    {
        public bool IsDataAvailable(Expression<Func<T, bool>> condition);
        public bool Any(Expression<Func<T, bool>> condition);
        public void Add(T entity);
        public void Edit(T entity);
        public void DeleteSkillData(Expression<Func<T, bool>> condition);
        public T GetSkillData(Expression<Func<T, bool>> condition);
        public T FindFirstEntity(Expression<Func<T, bool>> condition);

        public T FindDefaultEntity(Expression<Func<T, bool>> condition);

        public List<T> GetListData(Expression<Func<T, bool>> condition);
        public SkillModel<T> GetSkillList(string search, int pageNumber, string sorting,int pageSize, Expression<Func<T, bool>> condition, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
    }
}
