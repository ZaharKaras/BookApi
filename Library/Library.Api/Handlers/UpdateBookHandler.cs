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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request.Book);
            book.Id = request.Id;

            return await _unitOfWork.Books.Update(book);
        }
    }
}
