using AnimalCare.Data;
using DAO.Repositories;
using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Services
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext Context
        {
            get { return DataContext as AppDbContext; }
        }
        public UserRepository(AppDbContext context) :base(context)
        {
        }
        public async Task<IEnumerable<User>> GetAllUsersEventsAsync()
        {
            return await Context.TbUsers.Include(e => e.Events).ToListAsync();
        }

        public Task<User> UserWithEventsAsync(int idUser)
        {
            return Context.TbUsers.Include(a=>a.Events).SingleOrDefaultAsync(a=>a.IdUser == idUser);
        }

      
    }
}
