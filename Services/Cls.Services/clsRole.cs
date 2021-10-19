using DAO.Services;
using Domains;
using Services.UnitOfWorkManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Cls.Services
{
    public class clsRole : IRole
    {
        private readonly IUnitOfWork unitOfWork;

        public clsRole(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Role> CreateRoleAsync(Role createRole)
        {
            await unitOfWork.Roles.AddAsync(createRole);
            await unitOfWork.CommitAsync();
            return createRole;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await unitOfWork.Roles.GetAllAsync();
        }

        public async ValueTask<Role> GetRoleByIdAsync(int id)
        {
            return await unitOfWork.Roles.GetByIdAsync(id);
        }

        public async Task<Role> RemoveRole(Role delRole)
        {
            unitOfWork.Roles.Remove(delRole);
            await unitOfWork.CommitAsync();
            return delRole;
        }

        public async Task UpdateRoleAsync(Role currentRole, Role newRole)
        {
            currentRole.RoleName = newRole.RoleName;
            currentRole.RoleId_FK = newRole.RoleId_FK;
            currentRole.User.IdUser = newRole.User.IdUser;

            await unitOfWork.CommitAsync();
        }
    }
}
