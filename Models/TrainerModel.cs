using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class TrainerModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Please, Write Eamil in Correct Fromat !!")]
        public string Email { get; set; }
        [StringLength(250,MinimumLength =10)]
        public string Des { get; set; }
        [Url(ErrorMessage ="Please, Enter Correct Url!")]
        public string Website { get; set; }
        public System.DateTime Creation_Date { get; set; }

    }
}