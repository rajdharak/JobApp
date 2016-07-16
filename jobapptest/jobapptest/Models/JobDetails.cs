using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace jobapptest.Models
{
    public class JobDetails
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        [MaxLength(30)]
        public string JobName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int NoOfPositios { get; set; }
        
        public   virtual ICollection<Applicants> Applicant { get; set; }

    }
}