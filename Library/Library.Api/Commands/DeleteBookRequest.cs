using MediatR;

namespace Library.Api.Commands
{
    public class DeleteBookRequest : IRequest<bool>
    {
        public int Id { get; }
        public DeleteBookRequest(int id)
        {
            Id = id;
        }
    }
}
