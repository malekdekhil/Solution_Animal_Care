using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Services
{
    public interface IRole
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        ValueTask<Role> GetRoleByIdAsync(int id);
        Task<Role> RemoveRole(Role delRole);
        Task<Role> CreateRoleAsync(Role createRole);
        Task UpdateRoleAsync(Role currentRole, Role newRole);

    }
}
