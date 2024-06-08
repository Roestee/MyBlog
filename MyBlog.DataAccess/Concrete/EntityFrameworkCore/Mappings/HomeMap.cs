using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class HomeMap: IEntityTypeConfiguration<Home>
    {
        public void Configure(EntityTypeBuilder<Home> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Summary)
                .WithOne(x => x.Home)
                .HasForeignKey<Summary>(x => x.HomeId);

            builder.HasOne(x => x.AboutMe)
                .WithOne(x => x.Home)
                .HasForeignKey<AboutMe>(x => x.HomeId);

            builder.HasOne(x => x.MyService)
                .WithOne(x => x.Home)
                .HasForeignKey<MyService>(x => x.HomeId);

            builder.HasOne(x => x.MyWork)
                .WithOne(x => x.Home)
                .HasForeignKey<MyWork>(x => x.HomeId);

            builder.HasOne(x => x.ContactMe)
                .WithOne(x => x.Home)
                .HasForeignKey<ContactMe>(x => x.HomeId);


            builder.HasData(new Home { Id = 1 });
        }
    }
}
