using ProgrammersBlog.Core.Entity.Abstract;
using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entity.DTOs
{
    public class ArticleDto : DtoGetBase
    {
        public Article Article { get; set; }
    }
}
