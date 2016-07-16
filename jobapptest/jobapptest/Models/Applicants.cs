using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobapptest.Models
{
    public class Applicants
    {
        [Key]
        public int ApplyId { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }
        [DataType(DataType.Url)]
        [Url]
        public string GitHubUrl { get; set; }
        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual JobDetails Jobs { get; set; }
    }
}