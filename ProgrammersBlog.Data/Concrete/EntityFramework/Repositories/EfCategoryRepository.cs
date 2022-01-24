using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Core.Data.Concrete.EntityFramework;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {

        }

        public async Task<Category> GetById(int categoryId)
        {
            return await ApplicationDbContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get
            {
                return _context as ApplicationDbContext;            // cast
            }
        }
    }
}
