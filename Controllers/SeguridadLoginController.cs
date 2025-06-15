using CausaViva.Services.SeguridadLoginUsuario;
using Microsoft.AspNetCore.Mvc;

namespace CausaViva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadLoginController : ControllerBase
    {
        private readonly ISeguridadLoginRepository _seguridadLoginRepository;
        public SeguridadLoginController(ISeguridadLoginRepository seguridadLoginRepository)
        {
            _seguridadLoginRepository = seguridadLoginRepository;   
        }

        [HttpGet("UsuarioLogin")]
        public async Task<IActionResult> GetUsuarioLogin(String IdUsuario)
        {
            var usuario = await _seguridadLoginRepository.GetUsuarioLogin(IdUsuario);
            return Ok(usuario);

        }

        [HttpGet("OrganizacionLogin")]
        public async Task<IActionResult> GetOrganizacionLogin(String IdUsuario)
        {
            var usuario = await _seguridadLoginRepository.GetOrganizacionLogin(IdUsuario);
            return Ok(usuario);

        }
    }
}
