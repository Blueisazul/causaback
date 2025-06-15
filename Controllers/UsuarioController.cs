using CausaViva.DTOs.Usuario;
using CausaViva.Services.Distrito;
using CausaViva.Services.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CausaViva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("ID")]
        public async Task<IActionResult> GetUsuarioId(String IdUsuario)
        {
            var usuario = await _usuarioService.GetUsuarioId(IdUsuario);
            return Ok(usuario);

        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> InsertarUsuario([FromBody] UsuarioInsertarDTO usuario)
        {
            try
            {
                await _usuarioService.InsertarUsuarioAsync(usuario);
                return Ok(new { message = "Registrado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al insertar el usuario: {ex.Message}" });
            }
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> ActualizarUsuario([FromBody] UsuarioActualizarDTO usuario)
        {
            try
            {
                await _usuarioService.ActualizarUsuario(usuario);
                return Ok(new { message = "Actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al actualizar el usuario: {ex.Message}" });
            }
        }

        [HttpPut("ActualizarEstado")]
        public async Task<IActionResult> ActualizarEstadoUsuario([FromBody] UsuarioEstadoDTO usuario)
        {
            try
            {
                await _usuarioService.ActualizarEstadoUsuario(usuario);
                return Ok(new { message = "Estado actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al actualizar el estado del usuario: {ex.Message}" });
            }
        }

        [HttpPut("ActualizarContrasenia")]
        public async Task<IActionResult> ActualizarContraseniaUsuario([FromBody] UsuarioContraseniaDTO usuario)
        {
            try
            {
                await _usuarioService.CambioContrasenia(usuario);
                return Ok(new { message = "Contrasenia actualizada exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al actualizar la contrasenia: {ex.Message}" });
            }
        }

    }
}
