using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExpertsWebsite_ASPMVC.Models
{
    public class Customer
    {
        /// <summary>
        /// Entity class created by Darren Uong
        /// Contains properties for each Customer class
        /// </summary>

        [Required]
        public int CustomerId { set; get; }

        [Required]
        [Display(Name ="First Name")]
        public string CustFirstName { set; get; }

        [Required]
        [Display(Name = "Last Name")]

        public string CustLastName { set; get; }

        [Required]
        [Display(Name  = "Address")]

        public string CustAddress { set; get; }

        [Required]
        [Display(Name = "City")]

        public string CustCity { set; get; }

        [Required]
        [Display(Name = "Province")]

        public string CustProv { set; get; }

        [Required]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^[a-zA-z]\d[a-zA-z]\s\d[a-zA-Z]\d$", ErrorMessage = "Format should be A1A 2B2")]
        [DataType(DataType.PostalCode)]
        public string CustPostal { set; get; }

        [Required]
        [Display(Name = "Country")]
        public string CustCountry { set; get; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}", ErrorMessage = "Format should be in 10 digit number starting with area code")]
        [DataType(DataType.PhoneNumber)]
        public string CustHomePhone { set; get; }

        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Business Phone")]

        public string CustBusPhone { set; get; }
         

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string CustEmail { set; get; }

        [Required]
        [Display(Name = "Account Name")]
        public string CustAccount { set; get; }
    
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string CustPassword { set; get; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("CustPassword", ErrorMessage = "Passwords do not match!")]
        [DataType(DataType.Password)]
        public string ConfirmCustPassword { set; get; }

    }
}