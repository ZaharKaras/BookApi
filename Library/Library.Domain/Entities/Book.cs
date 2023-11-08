using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string? ISBN { get; set; }
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime BorrowedTime { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
