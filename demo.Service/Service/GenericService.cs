using demo.Entities.DataEntities;
using demo.Models.ViewModels;
using demo.Repository.Interface;
using demo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demo.Service.Service
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public T GetSkillData(Expression<Func<T, bool>> condition)
        {
            var skill = _genericRepository.DefaultData(condition);
            return skill;
        }
        public void DeleteSkillData(Expression<Func<T, bool>> condition)
        {
            var deletedSkill = _genericRepository.DefaultData(condition);
            _genericRepository.Remove(deletedSkill);
        }
        public bool Any(Expression<Func<T, bool>> condition)
        {
            return _genericRepository.AnyData(condition);
        }
        public bool IsDataAvailable(Expression<Func<T, bool>> condition)
        {
            return _genericRepository.AnyData(condition);
        }

        public T FindFirstEntity(Expression<Func<T, bool>> condition)
        {
            return _genericRepository.FirstData(condition);
        }

        public T FindDefaultEntity(Expression<Func<T, bool>> condition)
        {
            return _genericRepository.DefaultData(condition);
        }

        public List<T> GetListData(Expression<Func<T, bool>> condition)
        {
            return _genericRepository.List(condition);
        }

        public void Add(T entity)
        {
            _genericRepository.Add(entity);
        }
        public void Edit(T entity)
        {
            _genericRepository.Update(entity);
        }

        

        public SkillModel<T> GetSkillList(string search, int pageNumber, string sorting, int pageSize, Expression<Func<T, bool>> condition, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            if(pageSize == 1)
            {
                pageSize = 5;
            }
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            var query = _genericRepository.QueryableData(condition);
            if (orderBy != null)
                 query = orderBy(query);

            int pageCount = (int)Math.Ceiling((double)query.Count() / pageSize);
            var pagedSkills = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            SkillModel<T> skillModel = new SkillModel<T>();
            skillModel.skills = pagedSkills.ToList();
            skillModel.CurrentPage = pageNumber;
            skillModel.PageSize = pageSize;
            skillModel.PageCount = pageCount;

            return skillModel;
        }
    }
}
