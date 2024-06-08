using System.ComponentModel.DataAnnotations.Schema;
using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Entities
{
    public class AboutMe: IEntity
    {
        public int Id { get; set; }
        public int HomeId { get; set; }
        public string Description { get; set; }

        public virtual Home Home { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
    }
}

