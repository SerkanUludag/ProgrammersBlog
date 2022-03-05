using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entity.ComplexTypes
{
    public enum FilterBy
    {
        [Display(Name = "Category")]
        Category = 0,
        [Display(Name = "Date")]
        Date = 1,
        [Display(Name = "View Count")]
        ViewCount = 2,
        [Display(Name = "Comment Count")]
        CommentCount = 3
    }
}
