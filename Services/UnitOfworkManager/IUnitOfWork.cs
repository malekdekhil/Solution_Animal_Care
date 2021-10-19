using DAO.Repositories;
using DAO.Services;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitOfWorkManager
{
   public interface IUnitOfWork :IDisposable
    {
       
        IRepository<Event> Events { get; }
        IUserRepository Users { get; }
        IRepository<Role> Roles { get; }
        Task<int> CommitAsync();

    }
}
