using Application.Books.Queries.GetBooks;
using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetBooksQuery());
        return result switch
        {
            { HasError: true } => BadRequest(result),
            _ => Ok(result)
        };
    }
}
