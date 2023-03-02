using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstMVCApp.Models
{
    public class CodeSnippetModel
    {
        [Key]
        public Guid IdCodeSnippet { get; set; }

        [Required(ErrorMessage = "Title field is required!")]
        [StringLength(100, ErrorMessage = "Maximum allowed length for this field is 100")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content Code field is required!")]
        public string ContentCode { get; set; }

        [Required(ErrorMessage = "Member id field is required!")]
        public Guid IdMember { get; set; }

        [Required(ErrorMessage = "Revision field is required!")]
        [Range(0, int.MaxValue, ErrorMessage = "Must be a positive integer")]
        public int Revision { get; set; }

        [Required(ErrorMessage = "Date added field is required!")]
        public DateTime DateTimeAdded { get; set; }
        
        public bool IsPublished { get; set; }
    }
}
