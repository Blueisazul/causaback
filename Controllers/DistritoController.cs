using CausaViva.Services.Distrito;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CausaViva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritoController : ControllerBase
    {
        private readonly IDistritoService _distritoService;

        public DistritoController(IDistritoService distritoService) 
        {
            _distritoService = distritoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDistritosAll() 
        {
            var distritos = await _distritoService.GetDistritoAll();
            return Ok(distritos);

        }
    }
}
