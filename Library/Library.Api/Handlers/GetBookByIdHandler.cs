using AutoMapper;
using Library.Api.Queries;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Books.GetById(request.Id);
        }
    }
}
