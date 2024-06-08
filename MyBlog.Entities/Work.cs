using MyBlog.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Entities
{
    public class Work: IEntity
    {
        public int Id { get; set; }

        [ForeignKey(nameof(MyWorks))]
        public int MyWorksId { get; set; }

        [MaxLength(50, ErrorMessage = "Başlık 50 karakteri geçemez!")]
        public string Title { get; set; }
        public string Description { get; set; }

        [MaxLength(150, ErrorMessage = "Başlık 150 karakteri geçemez!")]
        public string? BackgroundImgUrl { get; set; }

        [MaxLength(150, ErrorMessage = "Başlık 150 karakteri geçemez!")]
        public string? WorkUrl { get; set; }

        public virtual MyWork MyWorks { get; set; }
    }
}
