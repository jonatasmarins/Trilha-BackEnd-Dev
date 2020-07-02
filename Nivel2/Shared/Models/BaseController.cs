using Microsoft.AspNetCore.Mvc;
using Nivel2.Shared.Models.Interfaces;

namespace Nivel2.Shared.Models
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