using Animal_Care_WebAPI.Resources.EventResources;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_Care_WebAPI.Resources.UserResources
{
    public class UserResource
    {

        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string City { get; set; }
        public string Address { get; set; }
        public string StreetInfo { get; set; }
        public string ZipCode { get; set; }
        public List<EventResource> Events { get; set; }
    }
}
