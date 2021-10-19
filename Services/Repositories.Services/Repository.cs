using AnimalCare.Data;
using DAO.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext DataContext;
        public Repository(AppDbContext _DataContext)
        {
           DataContext = _DataContext;
        }

        public async Task AddAsync(TEntity entity)
        {
              await DataContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await DataContext.Set<TEntity>().ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await DataContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
              DataContext.Set<TEntity>().Remove(entity);
        }
        
    }
}
