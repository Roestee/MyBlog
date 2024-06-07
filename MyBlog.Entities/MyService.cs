using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Entities
{
    public class MyService: IEntity
    {
        public int Id { get; set; }
        public int HomeId { get; set; }

        public virtual Home Home { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
