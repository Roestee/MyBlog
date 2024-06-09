using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities;

namespace MyBlog.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class MyServiceMap: IEntityTypeConfiguration<MyService>
    {
        public void Configure(EntityTypeBuilder<MyService> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(new MyService { Id=1, HomeId = 1 });
        }
    }
}
