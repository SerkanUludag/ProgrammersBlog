using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Core.Entity.Abstract
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus Status { get; set; }
        public virtual string Message { get; set; }
    }  
}
