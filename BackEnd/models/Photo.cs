using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.models
{
    [Table("Photos")]
    public class Photo : BaseEntity
    {
        [Required]
        public string publicId { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }
        
    }
}