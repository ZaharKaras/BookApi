using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
    }
}
