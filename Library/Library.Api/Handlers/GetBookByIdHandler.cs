using AutoMapper;
using Library.Api.Queries;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookRepository _books;
        private readonly IMapper _mapper;

        public GetBookByIdHandler(IBookRepository books, IMapper mapper)
        {
            _books = books;
            _mapper = mapper;
        }
        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _books.GetById(request.Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
