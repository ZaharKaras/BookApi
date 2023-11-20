using AutoMapper;
using Library.Api.Commands;
using Library.Api.DTOs;
using Library.Api.Queries;
using Library.DataService.Repositories.Interfaces;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Library.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
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

            var name = User.FindFirstValue(ClaimTypes.Name);

            var command = new CreateBookRequest(bookDto, name!);
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBookById), new {id = result.Id}, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var name = User.FindFirstValue(ClaimTypes.Name);

            var command = new UpdateBookRequest(bookDto, name!, id);
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
