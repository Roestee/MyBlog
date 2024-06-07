using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Entities
{
    public class Home : IEntity
    {
        public int Id { get; set; }
 
        public virtual Summary Summary { get; set; }
        public virtual AboutMe AboutMe { get; set; }
        public virtual MyService MyService { get; set; }
        public virtual MyWork MyWork { get; set; }
        public virtual ContactMe ContactMe { get; set; }
    }
}
