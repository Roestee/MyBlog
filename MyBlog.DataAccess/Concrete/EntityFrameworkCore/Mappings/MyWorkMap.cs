using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class MyWorkMap : IEntityTypeConfiguration<MyWork>
    {
        public void Configure(EntityTypeBuilder<MyWork> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(new MyWork {Id = 1, HomeId = 1 });
        }
    }
}
