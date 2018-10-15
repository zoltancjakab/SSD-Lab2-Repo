using System.ComponentModel.DataAnnotations;

namespace LabOneA.Models
{
    public class Car
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string VIN { get; set; }
        public string Color { get; set; }
        public int DealershipID { get; set; }
    }
}
