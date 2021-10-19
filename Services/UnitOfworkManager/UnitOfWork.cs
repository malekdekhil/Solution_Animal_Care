using AnimalCare.Data;
using DAO.Repositories;
using Domains;
using Services.Repositories.Services;
 
using System.Threading.Tasks;

namespace Services.UnitOfWorkManager
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext appDbContext;
        private IRepository<Event> _Events;
        private IUserRepository _Users;
        private IRepository<Role> _Roles;

        public UnitOfWork(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public IRepository<Event> Events => _Events = _Events?? new Repository<Event>(appDbContext);

        public IUserRepository Users => _Users = _Users ?? new UserRepository(appDbContext);

        public IRepository<Role> Roles => _Roles = _Roles ?? new Repository<Role>(appDbContext);

        public async Task<int> CommitAsync()
        {
            return await appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            appDbContext.Dispose();
        }
    }
}
