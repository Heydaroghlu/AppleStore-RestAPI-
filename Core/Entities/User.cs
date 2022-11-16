using Apple.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Core.Entities
{
    public class User : IDentityUser, ISoftDelete
    {
        public bool IsDelete { get; set; }
    }
}
