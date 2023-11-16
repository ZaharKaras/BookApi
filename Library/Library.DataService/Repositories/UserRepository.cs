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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByName(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Username == name);
        }
    }
}
