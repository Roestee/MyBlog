using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Entities
{
    public class Service: IEntity
    {
        public int Id { get; set; }

        [ForeignKey(nameof(MyService))]
        public int MyServicesId { get; set; }

        [Column("NVARCHAR(50)")]
        [MaxLength(50, ErrorMessage = "Başlık 50 karakteri geçemez!")]
        public string Title { get; set; }

        [Column("NVARCHAR(MAX)")]
        public string Description { get; set; }

        [Column("NVARCHAR(100)")]
        [MaxLength(150, ErrorMessage = "Başlık 150 karakteri geçemez!")]
        public string Icon { get; set; }

        public virtual MyService MyService{ get; set; }
    }
}
