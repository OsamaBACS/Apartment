using System.ComponentModel.DataAnnotations;

namespace BackEnd.models
{
    public class FurnishingType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}