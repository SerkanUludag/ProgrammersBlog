﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Core.Entity.Concrete
{
    public class MvcErrorModel                  // used at exception filter
    {
        public string Message { get; set; }
        public string Detail { get; set; }
    }
}
