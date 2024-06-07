using Microsoft.EntityFrameworkCore;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class MyBlogDbContext: DbContext
    {
        public DbSet<AboutMe> AboutMes { get; set; }
        public DbSet<ContactMe> ContactMes { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<MyService> MyServices { get; set; }
        public DbSet<MyWork> MyWorks { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Summary> Summaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MyBlogDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyBlogDbContext).Assembly);
        }
    }
}
