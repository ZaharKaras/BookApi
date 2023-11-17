using Library.DataService.Data;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected AppDbContext _context;
        internal DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }
        public async Task<bool> IsExist(int id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }
        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            if(await IsExist(id))
            {
                var entity = await GetById(id);
                _dbSet.Remove(entity!);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            if(await IsExist(entity.Id))
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
