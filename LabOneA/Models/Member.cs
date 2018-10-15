using System;
using System.ComponentModel.DataAnnotations;

namespace LabOneA.Models
{
    public class Member
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Username")]
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }

        public string Comapny { get; set; }
        public string Position { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
