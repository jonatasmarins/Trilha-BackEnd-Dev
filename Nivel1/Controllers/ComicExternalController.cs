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

        [HttpPost("Initialize")]
        public async Task<IActionResult> Initialize()
        {
            var resultResponse = await _comicExternalService.Initialize();

            return Response(resultResponse);
        }
    }
}