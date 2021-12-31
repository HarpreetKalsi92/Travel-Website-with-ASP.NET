using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExpertsWebsite_ASPMVC.Models;
using System.Security.Cryptography;
using System.Web.Helpers;

namespace TravelExpertsWebsite_ASPMVC.Controllers
{
    public class AccountController : Controller
    {


        // GET: RegisterConfirm
        public ActionResult RegisterConfirm()
        {

            if (Session["LastView"].ToString() == "~/Views/Cart/Packages.cshtml")
            {
                return View("~/ Views / Cart / Packages.cshtml");
            }
            else
            {
                return View();
            }

        }



        // GET: Admin
        public ActionResult Login()
        {
            ViewBag.Error = null;
            return View();
        }

        // GET: Logout
        public ActionResult Logout()
        {
            //Clear session
            Session["User"] = null;
            
            ViewBag.Error = "You have been successfully logged out";
            return View("~/Views/Account/Login.cshtml");
        }
        // POST: Account
        [HttpPost]
        public ActionResult Login(Login login)
        {

            if (AccountDB.ValidAccount(login) == true)
            {
                //Need to send customer back to previous page, if login is successful
                Session["User"] = AccountDB.GetCustomer(login.userAccount);

                if (Session["LastView"] != null)
                {
                    List<Package> packages = PackagesDB.GetPackages();

                    return View("~/Views/Cart/Packages.cshtml", packages);
                }
                else
                {
                    //return View("~/Views/Account/EditCustomer.cshtml", Session["User"]);
                    return View("~/Views/Home/Index.cshtml");
                }


            }
            else
            {
                return View("~/Views/Account/Login.cshtml");

            }

        }

        // GET: RegisterCustomer
        public ActionResult RegisterCustomer()
        {
           
            return View();
        }

        // POST: RegisterCustomer

        [HttpPost]
        public ActionResult RegisterCustomer(Customer customer)
        {
            ViewBag.Error = "";
            if (AccountDB.CreateUser(customer) == "created") //if sql insert successful, 
            {
                Session["User"] = customer; //store customer in session
                ViewBag.Error = "Customer entry created.";
                return View("~/Views/Account/RegisterConfirm.cshtml");


            }else if (AccountDB.CreateUser(customer) == "exists")
            {
                //Display error message** need help
                ViewBag.Error = "Customer already exists in database";
            }
            else
            {
                return View();
            }

            return View();

        }

        // GET: EditCustomer
        public ActionResult EditCustomer()
        {

            return View("~/Views/Account/EditCustomer.cshtml", Session["User"]);

        }

        [HttpPost]
        // POST: EditCustomer
        public ActionResult EditCustomer(Customer customer)
        {
            bool edited = AccountDB.EditUser(customer);
            if (edited == true)
            {
                ViewBag.Error = "Successfully edited";
            }
            else
            {
                ViewBag.Error = "Unable to edit information";

            }
            return View();
        }

    }
}