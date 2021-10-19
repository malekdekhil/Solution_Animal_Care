using AnimalCare_Client.Models;
using AnimalCare_Client.Pages.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimalCare_Client.Models
{
    public class UserModel
    {
       
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string StreetInfo { get; set; }
        public string ZipCode { get; set; }
        public List<EventModel> Events { get; set; }
         public List<RoleModel> Roles { get; set; }
        public CalendarModel Calendar { get; set; }
  
        public UserModel()
        {
            Calendar = new CalendarModel();
            Events = new List<EventModel>();
         }

         

       
    }
    
}
