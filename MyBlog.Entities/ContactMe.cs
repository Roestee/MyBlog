using System.ComponentModel.DataAnnotations;
using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Entities
{
    public class ContactMe: IEntity
    {
        public int Id { get; set; }
        public int HomeId { get; set; }

        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi giriniz!")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz!")]
        public string Phone { get; set; }

        [MaxLength(150, ErrorMessage = "CV link'i 150 karakteri geçemez!")]
        public string CVUrl { get; set; }

        public virtual Home Home { get; set; }
        public virtual ICollection<SocialMedia> SocialMedias { get; set; }
    }
}
