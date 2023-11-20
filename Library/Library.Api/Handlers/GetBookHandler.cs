using AutoMapper;
using Library.Api.Commands;
using Library.Api.DTOs;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Handlers
{
    public class GetBookHandler : IRequestHandler<CreateBookRequest, Book>
    {
        private readonly IBookRepository _books;
        private readonly IMapper _mapper;

        public GetBookHandler(IBookRepository books, IMapper mapper)
        {
            _books = books;
            _mapper = mapper;
        }
        public async Task<Book> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var book = _mapper.Map<Book>(request.Book);
                book.Author = request.Author;

                var existBook = _books.GetByISBN(book.ISBN!);
                if (existBook.Result != null)
                {
                    throw new Exception("Such an isbn already exists!");
                }

                await _books.Add(book);

                return book;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
            
        }
    }
}
