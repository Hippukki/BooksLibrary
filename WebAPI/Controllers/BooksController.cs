using Application.Books.Commands.SetBook;
using Application.Books.Queries.GetBooks;
using Application.DTOs.Book;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Query;
using Domain.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Application.Books.Queries.GetFilteredBooks;

namespace WebAPI.Controllers;

/// <summary>
/// Контроллер для работы с книгами
/// </summary>
[Route("api/books")]
[ApiController]
[SwaggerTag("Контроллер для работы с книгами")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="mediator"></param>
    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получение всех книг
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<Result<IEnumerable<BookDTO>>> Get()
    {
        return await _mediator.Send(new GetBooksQuery());
    }

    /// <summary>
    /// Получение книг по фильтру
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Todo
    ///     {
    ///        "searchValue": "Ибрагим",
    ///        "searchType": 3,
    ///        "orderByPublishDate": true,
    ///        "descending": true
    ///     }
    ///     
    /// </remarks>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filtered")]
    public async Task<Result<IEnumerable<BookDTO>>> Get([FromBody] Filter filter)
    {
        return await _mediator.Send(new GetFilteredBooksQuery(filter));
    }

    /// <summary>
    /// Добавление новой книги
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Todo
    ///     {
    ///        "name": "Война и мир",
    ///        "authorId": 1,
    ///        "publishedIn": "2005-08-27",
    ///        "isbn": "978-5-8114-2782-6",
    ///        "publisherId": 1,
    ///        "pagesCount": 2367
    ///     }
    ///     
    /// </remarks>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<Result> Set([FromBody] NewBookDTO model)
    {
        return ModelState.IsValid 
            ? await _mediator.Send(new SetBookCommand(model)) : 
            new ErrorResult(ErrorTypes.ValidateError, ModelState.GetErrors());
    }
}
