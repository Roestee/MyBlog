using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Core.Utilities.Helpers;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            HashingHelper.CreatePassword("Admin123.8501", out var passwordHashAdmin, out var passwordSaltAdmin);
            HashingHelper.CreatePassword("User1234.8501", out var passwordHashTest, out var passwordSaltTest);
            builder.HasData(new User[]
            {
                new User
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    Email = "admin@ibrahimcingi.com",
                    PasswordHash = passwordHashAdmin,
                    PasswordSalt = passwordSaltAdmin,
                    RoleId = 1,
                    IsActive = true,
                },
                new User
                {
                    Id = 2,
                    CreateDate = DateTime.Now,
                    Email = "test@ibrahimcingi.com",
                    PasswordHash = passwordHashTest,
                    PasswordSalt = passwordSaltTest,
                    RoleId = 2,
                    IsActive = true,
                }
            });
        }
    }
}
