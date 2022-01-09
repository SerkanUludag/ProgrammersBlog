using Microsoft.AspNetCore.Identity;
using ProgrammersBlog.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entity.Concrete
{
    public class User : IdentityUser<int>       
    {
        public string Picture { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
