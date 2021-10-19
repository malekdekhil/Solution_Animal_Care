using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Role
    {
        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public int RoleId_FK { get; set; }
        public User User { get; set; }
    }
}
