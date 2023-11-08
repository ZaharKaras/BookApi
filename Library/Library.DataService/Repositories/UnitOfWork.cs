using Library.DataService.Data;
using Library.DataService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        public IBookRepository Books {  get; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Books = new BookRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
