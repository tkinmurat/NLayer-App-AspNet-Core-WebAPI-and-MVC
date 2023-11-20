using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System.Linq.Expressions;

namespace NLayerRepo.Repos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDBContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T Entity)
        {
            await _dbSet.AddAsync(Entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
           await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T Entity)
        {
            _dbSet.Remove(Entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T Entity)
        {
            _dbSet.Update(Entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
           return _dbSet.Where(expression);
        }
    }
}
