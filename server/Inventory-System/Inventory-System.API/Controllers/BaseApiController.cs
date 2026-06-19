using Inventory_System.API.Responses;
using Inventory_System.Core.Bases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Inventory_System.API.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {     
        protected IActionResult NewResult<T>(Result<T> result)
        {

            var response = new ApiResponse<T>
            {
                Success = result.IsSuccess,
                Message  = result.MessageKey,
                Data = result.Data
            };

            return result.Status switch
            {
                ResultStatus.Success => Ok(response),
                ResultStatus.Created => Created(string.Empty, response),
                ResultStatus.NotFound => NotFound(response),
                ResultStatus.ValidationError => BadRequest(response),
                ResultStatus.Unauthorized => Unauthorized(response),
                _ => BadRequest(response)
            };
        }
    }
}
