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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Book> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request.Book);

            await _unitOfWork.Books.Add(book);

            return book;
        }
    }
}
