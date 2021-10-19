using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
   public class Speciality
    {
        public int IdSpeciality { get; set; }
        public string Name { get; set; }
        public int IdUser_FK { get; set; }
        public User User { get; set; }
    }
}
