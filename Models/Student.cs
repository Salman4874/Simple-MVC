using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolPortal.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Your Name")]
        public string firstName { get; set; }
        [Required]
        [DisplayName("Father Name")]
        public string lastName { get; set; }
        [Required]
        [DisplayName("Email")]
        public string email { get; set; }
        [Required]
        [DisplayName("Programme")]
        public string course { get; set; } 


    }
}
