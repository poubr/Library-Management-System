using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Domain.src.Shared;
using LibraryManagementSystem.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

// TODO: check for postgre's own errors to possibly here
// TODO: sort options
// TODO: filter options

namespace LibraryManagementSystem.Infrastructure.src.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DatabaseContext _databaseContext;

        public BaseRepository(DatabaseContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _databaseContext = dbContext;
        }

        public async Task<T> CreateOne(T newEntity)
        {
            await _dbSet.AddAsync(newEntity);
            await _databaseContext.SaveChangesAsync();
            return newEntity;
        }

        public async Task<T?> GetOne(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(QueryOptions queryOptions)
        {
            int skip = (queryOptions.PageNumber - 1) * queryOptions.PageSize;
            var query = _dbSet.AsQueryable();
            query = query.Skip(skip).Take(queryOptions.PageSize);
            return await query.ToListAsync();
        }

        public async Task<T> UpdateOne(T updatedEntity)
        {
            _dbSet.Update(updatedEntity);
            await _databaseContext.SaveChangesAsync();
            return updatedEntity;
        }

        public async Task<bool> DeleteOne(T foundEntity)
        {
            _dbSet.Remove(foundEntity);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}