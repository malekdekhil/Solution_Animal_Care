using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class User
    {
        public User()
        {
             Events = new List<Event>();
            Specialities = new List<Speciality>();
            Roles = new List<Role>();
            ListInfoProMember = new List<InformationForProMember>();
        }
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string StreetInfo { get; set; }
        public string ZipCode { get; set; }
          public IList<Event> Events { get; set; }
        public IList<Role> Roles { get; set; }
        public IList<Speciality> Specialities { get; set; }
        public IList<InformationForProMember> ListInfoProMember { get; set; }
     }
}
