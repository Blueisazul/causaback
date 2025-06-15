using CausaViva.DTOs.InscripcionVoluntariado;
using CausaViva.Models;
using CausaViva.Services.InscripcionVoluntariado;
using CausaViva.Services.Voluntariado_Requisito;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CausaViva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionVoluntariadoController : ControllerBase
    {
        private readonly IInscripcionVoluntariado _inscripcionVoluntariado;

        public InscripcionVoluntariadoController(IInscripcionVoluntariado inscripcionVoluntariado)
        {
            _inscripcionVoluntariado = inscripcionVoluntariado;
        }
    

        [HttpGet("PanelUsuario")]
        public async Task<IActionResult> GetInsVolPanelUsuario(String IdUsuario)
        {
            var inscripcion = await _inscripcionVoluntariado.GetInsVolPanelUsuario(IdUsuario);
            return Ok(inscripcion);
        }

        [HttpGet("PanelOrganizacion")]
        public async Task<IActionResult> GetInsVolPanelOrganizacion (String IdOrganizacion)
        {
            var inscripcion = await _inscripcionVoluntariado.GetInsVolPanelOrganizacion(IdOrganizacion);
            return Ok(inscripcion);
        }

        [HttpPost("Insertar")]
        public async Task<IActionResult> InsertarInscripcionVoluntariado([FromBody] InscripcionVoluntariadoDTO inscripcion)
        {
            try
            {
                await _inscripcionVoluntariado.InscripcionVol(inscripcion);
                return Ok(new { message = "Inscrito exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al registrar la inscripcion: {ex.Message}" });
            }
        }

        [HttpPut("ActualizacionEstado")]
        public async Task<IActionResult> ActualizarInscripcionVoluntariado([FromBody] InscripcionVolActualizarDTO inscripcion)
        {
            try
            {
                await _inscripcionVoluntariado.ActualizarEstadoInscripcion(inscripcion);
                return Ok(new { message = "Actualizacion de inscripcion exitosa" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al actualizar el estado de la inscripcion: {ex.Message}" });
            }
        }

    }
}
