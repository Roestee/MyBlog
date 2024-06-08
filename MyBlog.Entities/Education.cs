using MyBlog.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Entities
{
    public class Education: IEntity
    {
        public int Id { get; set; }

        [ForeignKey(nameof(AboutMe))]
        public int AboutMeId { get; set; }

        [MaxLength(100, ErrorMessage = "Başlık 100 karakteri geçemez!")]
        public string Title { get; set; }

        [MaxLength(60, ErrorMessage = "Başlık 60 karakteri geçemez!")]
        public string SchoolName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual AboutMe? AboutMe { get; set; }
    }
}
