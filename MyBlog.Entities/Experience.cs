using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Entities
{
    public class Experience: IEntity
    {
        public int Id { get; set; }

        [ForeignKey(nameof(AboutMe))]
        public int AboutMeId { get; set; }

        [Column("NVARCHAR(60)")]
        [MaxLength(60, ErrorMessage = "Başlık 60 karakteri geçemez!")]
        public string Title { get; set; }

        [Column("NVARCHAR(MAX)")]
        public string Description { get; set; }

        public bool StillWorking { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime? JobEndDate { get; set; }

        public virtual AboutMe AboutMe { get; set; }
    }
}
