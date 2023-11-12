using Library.Api.DTOs;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Commands
{
    public class UpdateBookRequest : IRequest<bool>
    {
        public BookDto Book { get; }
        public int Id { get; }
        public UpdateBookRequest(BookDto book, int id)
        {
            Book = book;
            Id = id;
        }

    }
}
