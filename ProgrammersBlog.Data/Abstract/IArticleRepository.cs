using ProgrammersBlog.Core.Data.Abstract;
using ProgrammersBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IArticleRepository : IEntityRepository<Article>
    {
    }
}
