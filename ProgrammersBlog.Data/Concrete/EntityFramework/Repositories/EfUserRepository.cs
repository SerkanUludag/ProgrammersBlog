﻿using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Core.Data.Concrete.EntityFramework;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfUserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {
        public EfUserRepository(DbContext context) : base(context)
        {

        }
    }
}