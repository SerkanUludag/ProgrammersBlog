using Microsoft.AspNetCore.Identity;
using ProgrammersBlog.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entity.Concrete
{
    public class Role : IdentityRole<int>           // primary key int
    {
        
    }
}
