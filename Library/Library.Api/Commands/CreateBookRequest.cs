using Library.Api.DTOs;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Commands
{
    public class CreateBookRequest : IRequest<Book>
    {
        public BookDto Book { get; }

        public CreateBookRequest(BookDto book)
        {
            Book = book;
        }

    }
}
