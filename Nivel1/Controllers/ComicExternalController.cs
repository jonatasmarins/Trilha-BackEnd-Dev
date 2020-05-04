using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nivel1.Domain.ExternalServices.Marvel.Interfaces;
using Nivel1.Domain.ExternalServices.Models;
using Nivel1.Shared.Models;
using Nivel1.Shared.Models.Interfaces;

namespace Nivel1.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ComicExternalController : BaseController
    {
        protected readonly IComicExternalService _comicExternalService;
        public ComicExternalController(IComicExternalService comicExternalService)
        {
            _comicExternalService = comicExternalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IResultResponse<IList<Comic>> resultResponse = null;
            resultResponse = _comicExternalService.Get();

            return Response(resultResponse);
        }
    }
}