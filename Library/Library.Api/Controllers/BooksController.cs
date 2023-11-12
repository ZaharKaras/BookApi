using AutoMapper;
using Library.Api.Commands;
using Library.Api.DTOs;
using Library.Api.Queries;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BooksController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var query = new GetBooksQuery();

            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var query = new GetBookByIdQuery(id);
            
            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound(id);

            return Ok(result);
        }

        [HttpGet("{isbn}")]
        public async Task<ActionResult<Book>> GetBookByISBN(string isbn)
        {
            var query = new GetBookByIsbnQuery(isbn);

            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<ActionResult<Book>> CreateBook([FromBody]BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new CreateBookRequest(bookDto);
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBookById), new {id = result.Id}, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UpdateBookRequest(bookDto, id);
            var result = await _mediator.Send(command);

            if(result is false)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var command = new DeleteBookRequest(id);
            var result = await _mediator.Send(command);

            if(result is false)
                return BadRequest();

            return NoContent();
        }
    }
}
