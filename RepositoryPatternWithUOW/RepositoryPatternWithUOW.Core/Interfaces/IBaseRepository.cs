using System.Linq.Expressions;
using System.Collections.Generic;
using RepositoryPatternWithUOW.Core.Consts;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int Id);
        Task<T> GetByIdAsync(int Id);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T, bool>> criteria,string[] includes=null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria,string[] includes=null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take,int skip);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take,int? skip,
            Expression<Func<T,object>>orderBy=null,string orderByDirection=OrderBy.Ascending, string[] includes = null);
        T Add(T entity);
       IEnumerable< T> AddRang(IEnumerable<T> entites);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRang(IEnumerable<T> entites);
        void Attach(T entity);
        int Count();
        int Count(Expression<Func<T, bool>> criteria);
    }
}
