using System.ComponentModel.DataAnnotations.Schema;
using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Entities
{
    public class Summary: IEntity
    {
        public int Id { get; set; }
        public int HomeId { get; set; }
        public string FullName { get; set; }
        public string JobPosition { get; set; }

        public virtual Home? Home { get; set; }
    }
}
