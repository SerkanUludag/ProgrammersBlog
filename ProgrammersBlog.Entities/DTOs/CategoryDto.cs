using ProgrammersBlog.Core.Entity.Abstract;
using ProgrammersBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entity.DTOs
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
    }
}
