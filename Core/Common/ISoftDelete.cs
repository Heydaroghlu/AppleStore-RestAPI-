﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Core.Common
{
    public interface ISoftDelete
    {
        public bool IsDelete { get; set; }
    }
}
