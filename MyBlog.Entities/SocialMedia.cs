using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlog.Core.Entities.Abstract;

namespace MyBlog.Entities
{
    public class SocialMedia: IEntity
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ContactMe))]
        public int ContactMeId { get; set; }

        [MaxLength(150, ErrorMessage = "Icon 150 karakteri geçemez!")]
        public string Icon { get; set; }

        [MaxLength(150, ErrorMessage = "Url 150 karakteri geçemez!")]
        public string Url { get; set; }

        public virtual ContactMe ContactMe { get; set; }
    }
}
