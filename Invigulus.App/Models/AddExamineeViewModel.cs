using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invigulus.App.Models
{
    public class AddExamineeViewModel
    {
        [Display(Name = "Examinee ID")]
        public string ExamineeId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string ExamineeFirstname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string ExamineeLastname { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string ExamineeEmail { get; set; }
    }
}
