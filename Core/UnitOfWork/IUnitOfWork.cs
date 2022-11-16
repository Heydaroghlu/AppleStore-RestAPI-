using Apple.Core.Entities;
using Apple.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Category,int> CategoryRepository { get; }
        public Task Commit();
    }
}
