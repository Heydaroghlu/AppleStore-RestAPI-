using Apple.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Core.Entities
{
    public class Product : BaseEntity<int>, ISoftDelete
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public int CategoryId { get; set; }
        public double DisCount { get; set; }
        public Category Category { get; set; }
        public bool IsDelete { get; set; }
    }
}
