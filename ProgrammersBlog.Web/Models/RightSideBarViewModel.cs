using ProgrammersBlog.Entity.Concrete;
using System.Collections.Generic;

namespace ProgrammersBlog.Web.Models
{
    public class RightSideBarViewModel
    {
        public IList<Category> Categories { get; set; }
        public IList<Article> Articles { get; set; }
    }
}
