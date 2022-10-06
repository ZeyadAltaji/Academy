using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Academy.Areas.Admin.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Passsword { get; set; }
        public string Message { get; set; }
    }
}