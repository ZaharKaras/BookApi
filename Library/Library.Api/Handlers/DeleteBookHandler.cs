using AutoMapper;
using Library.Api.Commands;
using Library.DataService.Repositories.Interfaces;
using MediatR;

namespace Library.Api.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, bool>
    {
        private readonly IBookRepository _books;
        private readonly IMapper _mapper;

        public DeleteBookHandler(IBookRepository books, IMapper mapper)
        {
            _mapper = mapper;
            _books = books;
        }
        public async Task<bool> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            var book = await _books.GetById(request.Id);

            if (book is null)
                return false;

            return await _books.Delete(request.Id);
        }
    }
}
