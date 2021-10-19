using Animal_Care_WebAPI.Resources.UserResources;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Care_WebAPI.Resources.EventResources
{
    public class EventResource
    {
        public int IdEvent { get; set; }
        public string Status { get; set; }
        public DateTime DateEvent { get; set; }
        public int UserId_FK { get; set; }
       
     }
}
