using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Queries
{
    public class GetBookByIsbnQuery : IRequest<Book>
    {
        public string? ISBN { get; set; }
        public GetBookByIsbnQuery(string isbn)
        {
            ISBN = isbn;
        }
    }
}
