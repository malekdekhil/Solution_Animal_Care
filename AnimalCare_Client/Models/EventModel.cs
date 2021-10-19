using AnimalCare_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalCare_Client.Models
{
    public class EventModel
    {
        public int IdEvent { get; set; }
        public DateTime DateEvent { get; set; }
        public string Status { get; set; }
        public int UserId_FK { get; set; }
        //public UserModel UserModel { get; set; }
      
       
    }
}
