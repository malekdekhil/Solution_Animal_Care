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
    public class clsUser : IUser
    {
        private readonly IUnitOfWork unitOfWork;

        public clsUser(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUserAsync(User CreateUser)
        {
            await unitOfWork.Users.AddAsync(CreateUser);
            await unitOfWork.CommitAsync();
            return CreateUser;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await unitOfWork.Users.GetAllAsync();
        } 
        public async Task<IEnumerable<User>> GetAllUsersWithEventsAsync()
        {
            return await unitOfWork.Users.GetAllUsersEventsAsync();
        }
        public async ValueTask<User> GetUserByIdAsync(int id)
        {
            return await unitOfWork.Users.GetByIdAsync(id);
        }

       

        public async Task<User> GetUserWithEventsAsync(int idUser)
        {
            return await unitOfWork.Users.UserWithEventsAsync(idUser);
        }
        public async Task<User> RemoveUserAsync(User delUser)
        {
            unitOfWork.Users.Remove(delUser);
            await unitOfWork.CommitAsync();
            return delUser;
        }
        public async Task UpdateUserAsync(User currentUser, User newUser)
        {
            currentUser.City = newUser.City;
            currentUser.StreetInfo = newUser.StreetInfo;
            currentUser.ZipCode = newUser.ZipCode;
            await unitOfWork.CommitAsync();
        }
    }
}
