using Application.Service.Commands.ClearAllData;
using Application.Service.Commands.SetDefaultData;
using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers;

/// <summary>
/// Сервисный контроллер
/// </summary>
[Route("api/service")]
[ApiController]
[SwaggerTag("Сервисный контроллер для работы с данными")]
public class ServiceController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="mediator"></param>
    public ServiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Заполнение БД начальными тестовыми данными
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<Result> Set()
    {
        return await _mediator.Send(new SetDefaultDataCommand());
    }

    /// <summary>
    /// Полная отчистка БД
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<Result> Delete()
    {
        return await _mediator.Send(new ClearAllDataCommand());
    }
}
