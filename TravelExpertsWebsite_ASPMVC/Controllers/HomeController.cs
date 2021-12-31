using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TravelExpertsWebsite_ASPMVC.Models;

namespace TravelExpertsWebsite_ASPMVC.Controllers
{

    /// <summary>
    /// Controller class for main (Home) links
    /// Authors: James Defant and Harpreet Kahlsi
    /// Date: Aug 8 2019
    /// </summary>
    public class HomeController : Controller
    {

        // James
        public ActionResult Index()
        {
            // Get time of day to display appropriate background and greeting
            int hour = DateTime.Now.TimeOfDay.Hours;
            TimeOfDay timeOfDay;

            if (hour < 12)
            {
                timeOfDay = TimeOfDay.Morning;
            }
            else if (hour >= 12 && hour < 18)
            {
                timeOfDay = TimeOfDay.Afternoon;
            }
            else
            {
                timeOfDay = TimeOfDay.Evening;
            }

            ViewData["TimeOfDay"] = timeOfDay;

            return View();
        }

        // Harpreet
        public ActionResult Links()
        {
            // Create array for links here (data)
            Dictionary<string, string> linksDict = new Dictionary<string, string>();

            linksDict.Add("https://www.singaporeair.com", "Singapore Airlines");
            linksDict.Add("https://www.Windstarcruises.com", "WindStarCruises");
            linksDict.Add("https://www.eaglerider.com", "Eaglerider Motorcycle Rentals");
            linksDict.Add("https://www.theparistours.com/#the-tour", "The Paris Tours");
            linksDict.Add("https://www.amari.com", "Amari Hotals");
            linksDict.Add("https://www.discountcar.com", "Discount Car Rentals");

            ViewData["Links"] = linksDict;

            return View();
        }

        // Harpreet
        public ActionResult Contact()
        {
            // Test ADO class
            List<Agency> agencies = AgenciesDB.GetAgencies();
            List<Agent> agents = AgentsDB.GetAgent();

            //foreach (Agent a in agents)
            //{
            //    Debug.WriteLine(a);
            //}
            ViewData["Agents"] = agents;
            ViewData["Agencies"] = agencies;


            return View();
        }
    }
}