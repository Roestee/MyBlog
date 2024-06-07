﻿using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfContactMeRepository: EfEntityRepositoryBase<ContactMe, MyBlogDbContext>, IContactMeRepository
    {
        public EfContactMeRepository(MyBlogDbContext context) : base(context)
        {
        }
    }
}
