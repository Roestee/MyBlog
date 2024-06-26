using MyBlog.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Entities
{
    public class Role: IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Rol ismi boş geçilemez.")]
        [MaxLength(50, ErrorMessage = "İsim 50 karakteri aşamaz!")]
        public string Name { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
