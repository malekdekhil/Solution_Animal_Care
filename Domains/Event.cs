using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Event
    {
        public int IdEvent { get; set; }
        public DateTime DateEvent { get; set; }
        public string Status { get; set; }
        public int UserId_FK { get; set; }
        public User User { get; set; }

      
    }
}
