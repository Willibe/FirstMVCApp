using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstMVCApp.Models
{
    public class CodeSnippetModel
    {
        [Key]
        public Guid IdCodeSnippet { get; set; }

        [StringLength(100, ErrorMessage = "Maximum allowed length for this field is 100")]
        public string Title { get; set; }
        
        public string ContentCode { get; set; }

        
        public Guid IdMember { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be a positive integer")]
        public int Revision { get; set; }
        
        public DateTime DateTimeAdded { get; set; }
        
        public bool IsPublished { get; set; }
    }
}
