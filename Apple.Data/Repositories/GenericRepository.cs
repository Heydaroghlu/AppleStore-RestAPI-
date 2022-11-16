using Apple.Core.Common;
using Apple.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Data.Repositories
{
    public class GenericRepository<TEntity, TPrimaryKey> : IGenericRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>(); 
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            return await GetInclude(includes).Where(predicate).ToListAsync();   
        }

        public Task<IEnumerable<TEntity>> GetAllPagenatedAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            return await GetInclude(includes).FirstOrDefaultAsync(predicate);
        }

        public IQueryable<TEntity> GetInclude(params string[] includes)
        {
            var query = Table.AsQueryable();
            GetIncludeAll(ref query, includes);
            return query;
        }

        public IQueryable<TEntity> GetIncludeAll(ref IQueryable<TEntity> query, string[] includes)
        {
            if (includes!=null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }

        public Task<int> GetTotalCount(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
           await  _context.AddAsync(entity);
            return entity;

        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
