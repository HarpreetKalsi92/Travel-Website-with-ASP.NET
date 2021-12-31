using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TravelExpertsWebsite_ASPMVC.Models
{
    public class Login
    {

        [Required(ErrorMessage = "Username is required!")]
        [Display(Name = "Account Name")]
        public string userAccount { set; get; }

        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string userPassword { set; get; }
    }
}