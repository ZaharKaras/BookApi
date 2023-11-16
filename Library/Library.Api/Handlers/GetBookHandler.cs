﻿using AutoMapper;
using Library.Api.Commands;
using Library.Api.DTOs;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Api.Handlers
{
    public class GetBookHandler : IRequestHandler<CreateBookRequest, Book>
    {
        private readonly IBookRepository _books;
        private readonly IMapper _mapper;

        public GetBookHandler(IBookRepository books, IMapper mapper)
        {
            _books = books;
            _mapper = mapper;
        }
        public async Task<Book> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request.Book);

            await _books.Add(book);

            return book;
        }
    }
}
