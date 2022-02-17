using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entity.Concrete;

namespace ProgrammersBlog.Entity.DTOs
{
    public class CommentListDto
    {
        public IList<Comment> Comments { get; set; }
    }
}
