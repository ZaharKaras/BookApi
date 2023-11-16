using AutoMapper;
using Library.Api.Queries;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Handlers
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository _books;
        private readonly IMapper _mapper;

        public GetBooksHandler(IBookRepository books, IMapper mapper)
        {
            _books = books;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _books.GetAll();
        }
    }
}
