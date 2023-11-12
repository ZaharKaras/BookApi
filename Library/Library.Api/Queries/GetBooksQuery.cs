using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Queries
{
    public class GetBooksQuery : IRequest<IEnumerable<Book>>
    {
    }
}
