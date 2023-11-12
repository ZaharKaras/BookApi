using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Queries
{
    public class GetBookByIdQuery: IRequest<Book>
    {
        public int Id { get; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
