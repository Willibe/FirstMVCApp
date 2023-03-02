using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class AnnouncementModel
    {
        [Key]
        public Guid? IdAnnouncement { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public DateTime ValidTo { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(250, ErrorMessage = "Maximum allowed length for this field is 250")]

        public string Title { get; set; }

        [MaxLength(250, ErrorMessage = "Maximum allowed length for this field is 250")]
        [Required(ErrorMessage = "This field is required!")]
        public string Text { get; set; }
        
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(1000, ErrorMessage = "Maximum allowed length for this field is 1000")]
        public string Tags { get; set; }


    }
}
