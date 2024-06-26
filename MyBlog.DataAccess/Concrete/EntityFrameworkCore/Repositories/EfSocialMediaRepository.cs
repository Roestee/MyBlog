﻿using MyBlog.Core.DataAccess.EntityFrameworkCore;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfSocialMediaRepository : EfEntityRepositoryBase<SocialMedia, RoesteBlogDbContext>, ISocialMediaRepository
    {
        public EfSocialMediaRepository(RoesteBlogDbContext context) : base(context)
        {
        }
    }
}
