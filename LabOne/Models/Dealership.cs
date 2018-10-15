using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LabOne.Models
{
    public class Dealership
    {
        [Display(Name="Dealership Id")]
        [Required]
        [Key]
        public int DealershipId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext = null)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, new ValidationContext(this), results);
            return results;
        }
    }
}
