using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
   public class InformationForProMember
    {
        public int IdInfoProMember { get; set; }
        public string Siret { get; set; }
        public bool isValidSubscribe { get; set; }
        public DateTime ActiveSubscribe { get; set; }
        public int UserId_Fk { get; set; }
        public User User { get; set; }
    }
}
