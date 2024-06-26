using Microsoft.EntityFrameworkCore;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class RoesteBlogDbContext: DbContext
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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=77.245.159.10\\MSSQLSERVER2019;Database=RoesteBlogDb;User Id=roesteAdmin;Password=SSii8501.DD,;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoesteBlogDbContext).Assembly);
        }
    }
}
