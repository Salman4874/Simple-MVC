using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolPortal.Models
{
    public class Teacher
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
        [DisplayName("Course")]
        public string course { get; set; }

    }
}
