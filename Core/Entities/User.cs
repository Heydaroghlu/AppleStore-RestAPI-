using Apple.Core.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Core.Entities
{
    public class User : IdentityUser, ISoftDelete
    {
        public string Name { get; set; }    
        public string Surname { get; set; }

        public bool IsDelete { get; set; }
    }
}
