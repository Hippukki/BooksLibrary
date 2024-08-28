using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers;
[Route("api/publishers")]
[ApiController]
[SwaggerTag("Контроллер для работы с издателями")]
public class PublishersController : ControllerBase
{
}
