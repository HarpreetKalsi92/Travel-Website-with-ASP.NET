using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExpertsWebsite_ASPMVC.Models;

namespace TravelExpertsWebsite_ASPMVC.Controllers
{
    /*
   *Author: Jaswinder Sangha
   *Date: Aug 5th, 2019
   */
    public class CartController : Controller
    {
        Package pack;
        List<Package> CartPackages = new List<Package>();

        // Display ALL the packages available for clients to purchase
        public ActionResult Packages()
        {
            List<Package> packages = PackagesDB.GetPackages();
            if (packages != null)
                return View(packages);
            else
                return RedirectToAction("Index");
        }
     
        // Display All the packages available in the cart
        public ActionResult Cart()
        {
            if (Session["User"] == null)
            {
                Session["LastView"] = "~/Views/Cart/Packages.cshtml";
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                var CartPackageCookie = Request.Cookies["id"];
                if (CartPackageCookie != null)
                {
                    var PackageID = CartPackageCookie.Value;
                    var pid = PackageID.Split(',');
                    if (pid.Length >= 1)
                    {
                        foreach (string i in pid)
                        {
                            if (i != "")
                            {
                                int packId = Convert.ToInt32(i);
                                pack = PackagesDB.GetPackagesById(Convert.ToInt32(packId));
                                CartPackages.Add(pack);
                            }
                        }
                    }
                    decimal total = 0;
                    foreach (var pu in CartPackages)
                        total += pu.PkgBasePrice;
                    ViewBag.TotalAmount = total.ToString("c");
                    return View(CartPackages);
                }
                else
                {
                    return View("EmptyCart");
                }
            }
        }

        //Display the message that shopping cart is empty
        public ActionResult EmptyCart()
        {
            return View();
        }

        //Delete package from Cart - Not Working at this point.
        public ActionResult DeleteFromCart()
        {
            var CartPackageCookie = Request.Cookies["id"];
            if (CartPackageCookie != null)
            {
                var PackageID = CartPackageCookie.Value;
                int pid = Convert.ToInt32(PackageID);
          }
            return RedirectToAction("Cart");
        }
/*
        // Default Index Controller
        public ActionResult Index()
        {
            return View();
        }
*/
    }
}