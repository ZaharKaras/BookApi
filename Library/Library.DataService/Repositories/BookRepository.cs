using Library.DataService.Data;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataService.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Book?> GetByISBN(string ISBN)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.ISBN == ISBN);

        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result != null)
                {
                    return false;
                }

                _context.Books.Remove(result);
                await _context.SaveChangesAsync();
                return true;

            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        public override async Task<bool> Update(Book entity)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);

                if (result == null)
                    return false;

                result.ISBN = entity.ISBN;
                result.Name = entity.Name;
                result.Description = entity.Description;
                result.Author = entity.Author;
                result.Genre = entity.Genre;
                result.BorrowedTime = entity.BorrowedTime;
                result.ReturnTime = entity.ReturnTime;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
