using AutoMapper;
using Library.Api.Queries;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Handlers
{
    public class GetBookByIsbnHandler : IRequestHandler<GetBookByIsbnQuery, Book>
    {

        private readonly IBookRepository _books;
        private readonly IMapper _mapper;

        public GetBookByIsbnHandler(IBookRepository books, IMapper mapper)
        {
            _books = books;
            _mapper = mapper;
        }
        public async Task<Book> Handle(GetBookByIsbnQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _books.GetByISBN(request.ISBN);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
