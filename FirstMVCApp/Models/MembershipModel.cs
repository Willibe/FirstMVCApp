using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class MembershipModel
    {

        [Key]
        public Guid IdMembership { get; set; }

        [Required(ErrorMessage = "Member id field is required!")]
        public Guid IdMember { get; set; }

        [Required(ErrorMessage = "Membership type id field is required!")]
        public Guid IdMembershipType { get; set; }


        [Required(ErrorMessage = "Start date field is required!")]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "End date field is required!")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Level field is required!")]
        [Range(0, int.MaxValue, ErrorMessage = "Must be a positive integer")]
        public int Level { get; set; }

    }
}
