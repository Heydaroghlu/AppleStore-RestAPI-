using Apple.Core.Entities;
using Apple.Core.Repositories;
using Apple.Core.UnitOfWork;
using Apple.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Category, int> CategoryRepository { get;}
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            CategoryRepository = new GenericRepository<Category, int>(_context);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
