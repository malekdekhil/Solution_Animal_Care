using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersEventsAsync();
        Task<User> UserWithEventsAsync(int idUser);
      }
}
