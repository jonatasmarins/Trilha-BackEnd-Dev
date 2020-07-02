using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nivel2.AppServices.Interfaces;
using Nivel2.Models.Requests;
using Nivel2.Models.Responses;
using Nivel2.Shared.Models;
using Nivel2.Shared.Models.Interfaces;

namespace Nivel2.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CartController : BaseController
    {
        private readonly ICartAppService _appService;
        public CartController(ICartAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("CartView/{CartID}")]
        public async Task<IActionResult> Get(int CartID)
        {
            if(!ModelState.IsValid) {
                return Response(new ResultResponse("Parâmetros inválidos"));
            }

            IResultResponse<IList<CartResponse>> carts = await _appService.Get(CartID);

            return Response(null);
        }

        [HttpGet("CartViewAll")]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid) {
                return Response(new ResultResponse("Parâmetros inválidos"));
            }

            IResultResponse<IList<CartResponse>> carts = await _appService.GetAll();

            return Response(null);
        }

        [HttpGet("AddItem")]
        public async Task<IActionResult> Add(CartItemAddRequest request)
        {
            return Response(null);
        }

        [HttpGet("RemoveItem")]
        public async Task<IActionResult> Remove(CartItemRemoveRequest request)
        {
            return Response(null);
        }

        [HttpGet("UpdateItem")]
        public async Task<IActionResult> Update(CartItemUpdateRequest request)
        {
            return Response(null);
        }
    }
}