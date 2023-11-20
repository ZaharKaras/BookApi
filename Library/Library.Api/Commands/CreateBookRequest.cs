using Library.Api.DTOs;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Commands
{
    public class CreateBookRequest : IRequest<Book>
    {
        public BookDto Book { get; }
        public string Author { get; }

        public CreateBookRequest(BookDto book, string author)
        {
            Book = book;
            Author = author;
        }

    }
}
