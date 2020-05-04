using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nivel1.Domain.Services.Interfaces;
using Nivel1.Models;
using Nivel1.Models.Responses;
using Nivel1.Shared.Models;
using Nivel1.Shared.Models.Interfaces;

namespace Nivel1.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : BaseController
    {
        protected readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.Get();

            
            return Response(result);
        }

        [HttpGet("GetByDocument")]
        public async Task<IActionResult> GetByDocument(string document)
        {
            if (!ModelState.IsValid)
            {
                return Response(new ResultResponse("Valor Inválido"));
            }

            IResultResponse<UserResponse> result = await _userService.GetByDocument(document);
            return Response(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody]UserCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Response(new ResultResponse("Usuário de entrada Inválido"));
            }

            IResultResponse result = await _userService.Create(request);
            return Response(result);
        }

        [HttpPut("{documentNumber}")]
        public async Task<IActionResult> Update(string documentNumber, [FromBody]UserUpdateRequest user)
        {
            if (!ModelState.IsValid)
            {
                return Response(new ResultResponse("Usuário de entrada Inválido"));
            }

            IResultResponse result = await _userService.Update(documentNumber, user);
            return Response(result);
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(string document)
        {
            if (!ModelState.IsValid)
            {
                return Response(new ResultResponse("Valor Inválido"));
            }

            IResultResponse result = await _userService.Delete(document);

            return Response(result);
        }
    }
}