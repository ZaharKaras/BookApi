using AutoMapper;
using Library.Api.Queries;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Handlers
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBooksHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Books.GetAll();
        }
    }
}
