using AutoMapper;
using Library.Api.Commands;
using Library.DataService.Repositories.Interfaces;
using MediatR;

namespace Library.Api.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetById(request.Id);

            if (book is null)
                return false;

            return await _unitOfWork.Books.Delete(request.Id);
        }
    }
}
