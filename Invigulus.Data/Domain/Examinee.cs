﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invigulus.Data.Domain
{
    public partial class Examinee
    {
        [Display(Name = "Examinee ID")]
        public int ExamineeId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string ExamineeFirstname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string ExamineeLastname { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string ExamineeEmail { get; set; }

        public virtual ICollection<UserSession> UserSession { get; set; }
    }
}
