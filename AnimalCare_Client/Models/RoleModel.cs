using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalCare_Client.Models
{
    public class RoleModel
    {
        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public int RoleId_FK { get; set; }
     }
}
