using System;
using System.ComponentModel.DataAnnotations;

namespace TravelExpertsWebsite_ASPMVC.Models
{
    /// <summary>
    /// Class to hold data for single row from Packages table in TravelExperts database
    /// Author: James Defant
    /// Date: Aug 9 2019
    /// </summary>
    public class Package
    {
        [Required]
        public int PackageId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Package Name")]
        public string PkgName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = true)]
        public DateTime? PkgStartDate { get; set; } // Nullable

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = true)]
        public DateTime? PkgEndDate { get; set; }   // Nullable

        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string PkgDesc { get; set; }         // Nullable

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal PkgBasePrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal? PkgAgencyCommission { get; set; }   // Nullable

        [DataType(DataType.ImageUrl)]
        public string PkgImage { get; set; }   // Nullable


        //--------------------------------------------------------

        public override string ToString()
        {
            return "PackageId: " + PackageId.ToString() + "\nPkgName: " + PkgName;
        }
    }
}
