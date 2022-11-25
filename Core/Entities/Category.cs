using Apple.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Core.Entities
{
    public class Category:BaseEntity<int>,ISoftDelete
    {
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public List<Product> Products { get; set; }
    }
}
