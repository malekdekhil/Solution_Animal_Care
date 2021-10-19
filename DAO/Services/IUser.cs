using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Services
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAllUsersWithEventsAsync();
         Task<IEnumerable<User>> GetAllUsersAsync();
         ValueTask<User> GetUserByIdAsync(int id);
         Task<User> GetUserWithEventsAsync(int idUser);
        Task<User> RemoveUserAsync(User delUser);
        Task<User> CreateUserAsync(User CreateUser);
        Task UpdateUserAsync(User currentUser, User newUser);
    }
}
