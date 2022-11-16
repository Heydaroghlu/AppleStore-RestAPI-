using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Core.Common
{
    public class BaseEntity<TEntity>
    {
        public TEntity Id { get; set; }
        public DateTime CreatedTime { get; } = DateTime.UtcNow.AddHours(4);

    }
}
