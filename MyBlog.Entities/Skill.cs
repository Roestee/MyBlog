using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Entities
{
    public class Skill: IEntity
    {
        public int Id { get; set; }

        [ForeignKey(nameof(AboutMe))]
        public int AboutMeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Range(0,101)]
        public int Rate { get; set; }

        public virtual AboutMe AboutMe { get; set; }
    }
}
