﻿using JobPortal.Domain.Interfaces;
using JobPortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobPortal.Infrastructure.Repository
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly IDapperRepository<T> _dapperRepository;
        public GenericRepository(AppDbContext context, IDapperRepository<T> dapperRepository)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _dapperRepository = dapperRepository;
        }

        public async Task<int> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await _context.SaveChangesAsync();  
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return await _context.SaveChangesAsync();  
            }
            return 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            string query = $"SELECT * FROM {typeof(T).Name}s";
            return await _dapperRepository.GetAllAsync(query);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            string query = $"SELECT * FROM {typeof(T).Name}s WHERE Id = @Id";
            return await _dapperRepository.GetByIdAsync(query, new { Id = id });
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
