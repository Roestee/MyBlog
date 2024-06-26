using System.ComponentModel.DataAnnotations;
using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen bir role seçiniz!")]
        public int RoleId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required(ErrorMessage = "Aktiflik alanı boş geçilemez!")]
        public bool IsActive { get; set; } = true;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public virtual Role? Role { get; set; }
    }
}
