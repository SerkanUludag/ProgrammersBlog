using ProgrammersBlog.Entity.Concrete;
using System.Collections.Generic;

namespace ProgrammersBlog.Web.Areas.Admin.Models
{
    public class UserWithRolesViewModel
    {
        public User User { get; set; }
        public IList<string> Roles { get; set; }
    }
}
