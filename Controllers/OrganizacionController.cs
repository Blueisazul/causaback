using CausaViva.DTOs.Organizacion;
using CausaViva.Services.Organizacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CausaViva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizacionController : ControllerBase
    {
        private readonly IOrganizacionService _organizacionService;

        public OrganizacionController(IOrganizacionService organizacionService)
        {
            _organizacionService = organizacionService;
        }

        [HttpGet("ID")]
        public async Task<IActionResult> GetOrganizacionId(String IdOrganizacion)
        {
            var organizacion = await _organizacionService.GetOrganizacionId(IdOrganizacion);
            return Ok(organizacion);

        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> InsertarOrganizacion([FromBody] OrganizacionInsertarDTO organizacion)
        {
            try
            {
                await _organizacionService.InsertarOrganizacionAsync(organizacion);
                return Ok(new { message = "Registrado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al registrar la organizacion: {ex.Message}" });
            }
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> ActualizarOrganizacion([FromBody] OrganizacionActualizarDTO organizacion)
        {
            try
            {
                await _organizacionService.ActualizarOrganizacion(organizacion);
                return Ok(new { message = "Actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al actualizar la organizacion: {ex.Message}" });
            }
        }

        [HttpPut("ActualizarEstado")]
        public async Task<IActionResult> ActualizarEstadoUsuario([FromBody] OrgVolReqActualizarEstadoDTO organizacion)
        {
            try
            {
                await _organizacionService.ActualizarEstadoOrgVolReq(organizacion);
                return Ok(new { message = "Estado de organizacion, voluntariado y requisitos actualizados exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al actualizar: {ex.Message}" });
            }
        }

        [HttpPut("ActualizarContrasenia")]
        public async Task<IActionResult> ActualizarContraseniaUsuario([FromBody] CambioContraseniaOrg organizacion)
        {
            try
            {
                await _organizacionService.CambioContraseniaOrg(organizacion);
                return Ok(new { message = "Contrasenia actualizada exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al actualizar la contrasenia: {ex.Message}" });
            }
        }


    }
}
