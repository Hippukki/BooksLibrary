using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers;
[Route("api/authors")]
[ApiController]
[SwaggerTag("Контроллер для работы с авторами")]
public class AuthorsController : ControllerBase
{
}
