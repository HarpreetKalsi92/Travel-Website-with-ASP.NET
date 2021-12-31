using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelExpertsWebsite_ASPMVC.Models
{
    /*
   *Author: Jaswinder Sangha
   *Date: Aug 5th, 2019
   */
    public class Cart 
    {
        //List of packages in the cart
        public List<Package> CartPackages { get; set; }
        public int PackId { get; set; }
        public decimal PkgBasePrice { get; set; }
    }
}