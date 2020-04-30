using Microsoft.AspNetCore.Mvc;
using Nivel1.Shared.Models.Interfaces;

namespace Nivel1.Shared.Models
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }

        protected new IActionResult Response(IResultResponse resultResponse)
        {
            return Ok(resultResponse);
        }

        protected new IActionResult Response<T>(IResultResponse<T> resultResponse)
        {
            return Ok(resultResponse);
        }
    }
}