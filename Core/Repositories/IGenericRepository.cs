using Apple.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Core.Repositories
{

    public interface IGenericRepository<TEntity,in TPrimaryKey>:IDisposable where TEntity : BaseEntity<TPrimaryKey>
    {
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        IQueryable<TEntity> GetInclude(params string[] includes);
        IQueryable<TEntity> GetIncludeAll(ref IQueryable<TEntity> quer, string[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>> predicate, params string[] includes);
        Task<IEnumerable<TEntity>> GetAllPagenatedAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes);
        Task<int> GetTotalCount(Expression<Func<TEntity, bool>> predicate);
        void Remove(TEntity entity);


    }
}
