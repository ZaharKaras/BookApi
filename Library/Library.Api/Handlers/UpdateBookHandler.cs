using AutoMapper;
using Library.Api.Commands;
using Library.Api.DTOs;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Handlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, bool>
    {
        private readonly IBookRepository _books;
        private readonly IMapper _mapper;

        public UpdateBookHandler(IBookRepository books, IMapper mapper)
        {
            _books = books;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var book = _mapper.Map<Book>(request.Book);
                book.Id = request.Id;

                return await _books.Update(book);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
            
        }
    }
}
