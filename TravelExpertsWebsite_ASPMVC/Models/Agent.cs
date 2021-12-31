using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExpertsWebsite_ASPMVC.Models
{
    public class Agent
    {
        [Required]
        public int AgentId { get; set; }
      
        [DataType(DataType.Text)]
        public string AgtFirstName{ get; set; }

        [DataType(DataType.Text)]
       
        public string AgtMiddleInitial  { get; set; } 

        [DataType(DataType.Text)]
     
        public string AgtLastName  { get; set; }   

        [DataType(DataType.PhoneNumber)]
        public string AgtBusPhone { get; set; }      

        
        [DataType(DataType.EmailAddress)]
        public string AgtEmail{ get; set; }

        [DataType(DataType.Text)]
        public string AgtPosition { get; set; }   

        [DataType(DataType.Text)]
        public int? AgencyId { get; set; }

        public string Name
        {
            get
            {
                string temp = AgtFirstName + " ";

                if(AgtMiddleInitial!= "")
                {
                    temp += AgtMiddleInitial + " ";
                }
                temp+= AgtLastName;
                return temp;
            }
        }

        //--------------------------------------------------------

        public override string ToString()
        {
            return "AgentId: " + AgentId.ToString() + "\nAgtName: " + AgtFirstName +"\nAgtMiddleInitial: " + AgtMiddleInitial
                                                    + "\nAgtLastName: " + AgtLastName + "\nAgtBusPhone: " + AgtBusPhone
                                                    + "\nAgtEmail: " + AgtEmail + "\nAgtPosition: " + AgtPosition
                                                    + "\nAgencyId: " + AgencyId;



        }
    }
}
       

