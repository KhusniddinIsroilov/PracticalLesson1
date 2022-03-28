using Microsoft.EntityFrameworkCore;
using PracticalLesson1.Api.Data.IRepositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PracticalLesson1.Api.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
#pragma warning disable

        protected PracticalDbContext _dbContext;
        protected DbSet<T> _dbSet;
        public GenericRepository(PracticalDbContext practicalDbContext)
        {
            _dbContext = practicalDbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var result = await _dbSet.FirstOrDefaultAsync(expression);
            if (result == null)
                return false;
            _dbSet.Remove(result);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? _dbSet : _dbSet.Where(expression);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
