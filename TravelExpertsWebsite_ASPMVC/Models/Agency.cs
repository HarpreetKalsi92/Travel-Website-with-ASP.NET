using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExpertsWebsite_ASPMVC.Models
{
    public class Agency
    {
        [Required]
        public int AgencyId { get; set; }

        [DataType(DataType.Text)]
        public string AgncyAddress { get; set; }

        [DataType(DataType.Text)]

        public string AgncyCity { get; set; }

        [DataType(DataType.Text)]

        public string AgncyProv { get; set; }

        [DataType(DataType.PostalCode)]
        public string AgncyPostal { get; set; }


        [DataType(DataType.Text)]
        public string AgncyCountry { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string AgncyPhone { get; set; }

        [DataType(DataType.Text)]
        public string AgncyFax { get; set; }

        public string Postalcode
        {
            get
            {
                string temp = "";
                for(int i = 0; i<AgncyPostal.Length;i++)
                {
                    if(i==3)
                    {
                        temp += " ";
                    }
                    temp += AgncyPostal[i];
                }

 
                return temp;
            }
        }

        public string BusinessPhone
        {
            get
            {
               
                return GetPhone(AgncyPhone);
            }
        }
        public string BusinessFax
        {
            get
            {

                return GetPhone(AgncyFax);
            }
        }
        private string GetPhone(string num)
        {
            string temp = "(";
            for (int i = 0; i < num.Length; i++)
            {
                if (i == 3)
                {
                    temp += ")-";
                }
                if (i == 6)
                {
                    temp += "-";
                }
                temp += num[i];
            }

            return temp;
        }
        public override string ToString()
        {
            return "AgencyId: " + AgencyId.ToString() + "\nAgncyAddress: " + AgncyAddress + "\nAgncyCity: " + AgncyCity
                                                    + "\nAgncyProv: " + AgncyProv + "\nAgncyPostal: " + AgncyPostal
                                                    + "\nAgncyCountry: " + AgncyCountry + "\nAgncyPhone: " + AgncyPhone
                                                    + "\nAgncyFax: " + AgncyFax;


        }
    }
}