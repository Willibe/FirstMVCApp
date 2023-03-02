using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class MemberModel
    {

        [Key]
        public Guid IdMember { get; set; }

        [Required(ErrorMessage = "Name Field is required!")]
        [MaxLength(250, ErrorMessage = "Maximum allowed length for this field is 250")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Title Field is required!")]
        [MaxLength(100, ErrorMessage = "Maximum allowed length for this field is 100")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Position Field is required!")]
        [MaxLength(250, ErrorMessage = "Maximum allowed length for this field is 250")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Description Field is required!")]
        [MaxLength(1000, ErrorMessage = "Maximum allowed length for this field is 1000")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Resume Field is required!")]
        public string Resume { get; set; }
    }
}
