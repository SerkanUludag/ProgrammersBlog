using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entity.ComplexTypes
{
    public enum OrderBy
    {
        [Display(Name = "Date")]
        Date = 0,
        [Display(Name = "View Count")]
        ViewCount = 1,
        [Display(Name = "Comment Count")]
        CommentCount = 2
    }
}
