using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        // [Required]
        public string Country { get; set; }
        
    }
}