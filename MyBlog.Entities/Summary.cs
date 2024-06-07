using System.ComponentModel.DataAnnotations.Schema;
using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Entities
{
    public class Summary: IEntity
    {
        public int Id { get; set; }
        public int HomeId { get; set; }

        [Column("NVARCHAR(60)")]
        public string FullName { get; set; }

        [Column("NVARCHAR(100)")]
        public string JobPosition { get; set; }

        public virtual Home Home { get; set; }
    }
}
