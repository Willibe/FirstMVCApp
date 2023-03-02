using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class MembershipModel
    {

        [Key]
        public Guid IdMembership { get; set; }

        [Required]
        public Guid IdMember { get; set; }

        [Required]
        public Guid IdMembershipType { get; set; }
     
        public DateTime StartDate { get; set; }
      
        public DateTime EndDate { get; set; }
      
        public int Level { get; set; }

    }
}
