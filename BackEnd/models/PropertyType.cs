using System.ComponentModel.DataAnnotations;

namespace BackEnd.models
{
    public class PropertyType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}