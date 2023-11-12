using AutoMapper;
using Library.Api.Queries;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Handlers
{
    public class GetBookByIsbnHandler : IRequestHandler<GetBookByIsbnQuery, Book>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookByIsbnHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Book> Handle(GetBookByIsbnQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Books.GetByISBN(request.ISBN);
        }
    }
}
