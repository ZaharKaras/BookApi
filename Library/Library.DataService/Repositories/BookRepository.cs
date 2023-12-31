﻿using Library.DataService.Data;
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
            var book = await _dbSet.FirstOrDefaultAsync(x => x.ISBN == ISBN);
            return book;
        }

        //public override async Task<bool> Delete(int id)
        //{
        //    var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        //    if (result is null)
        //    {
        //        return false;
        //    }

        //    _context.Books.Remove(result);
        //    await _context.SaveChangesAsync();
        //    return true;

        //}

        //public override async Task<bool> Update(Book entity)
        //{
        //    var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);

        //    if (result is null)
        //        return false;

        //    result.ISBN = entity.ISBN;
        //    result.Name = entity.Name;
        //    result.Description = entity.Description;
        //    result.Author = entity.Author;
        //    result.Genre = entity.Genre;
        //    result.BorrowedTime = entity.BorrowedTime;
        //    result.ReturnTime = entity.ReturnTime;

        //    await _context.SaveChangesAsync();

        //    return true;
        //}
    }
}
