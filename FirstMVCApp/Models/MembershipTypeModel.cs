using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class MembershipTypeModel
    {
        [Key]
        public Guid IdMembershipType { get; set; }

        [Required(ErrorMessage = "Name field is required!")]
        [MaxLength(100, ErrorMessage = "Maximum allowed length for this field is 100")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description field is required!")]
        [MaxLength(250, ErrorMessage = "Maximum allowed length for this field is 250")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Subscription length field is required!")]
        [Range(0, 1000, ErrorMessage = "Only values between 0 and 1000 are accepted")]
        public int SubscriptionLengthInMonths { get; set; }

    }
}
