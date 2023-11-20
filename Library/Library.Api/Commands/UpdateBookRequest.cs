using Library.Api.DTOs;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Commands
{
    public class UpdateBookRequest : IRequest<bool>
    {
        public BookDto Book { get; }
        public string Author { get; }
        public int Id { get; }
        public UpdateBookRequest(BookDto book, string author ,int id)
        {
            Book = book;
            Author = author;
            Id = id;
        }

    }
}
