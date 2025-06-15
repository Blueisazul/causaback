using CausaViva.DTOs.Usuario;
using CausaViva.DTOs.Voluntariado_Requisito.Voluntariado;
using CausaViva.Services.Voluntariado_Requisito;
using Microsoft.AspNetCore.Mvc;

namespace CausaViva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoluntariadoRequisitoController : ControllerBase
    {
        private readonly IVoluntariado_RequisitoService _voluntariadoRequisitoService;

        public VoluntariadoRequisitoController(IVoluntariado_RequisitoService voluntariadoRequisitoService  )
        {
            _voluntariadoRequisitoService = voluntariadoRequisitoService;
        }

        [HttpGet("VoluntariosPanelUsuarioID")]
        public async Task<IActionResult> GetVoluntariadoIdPanelUsuario(Int32 IdVoluntariado)
        {
            object response;
            if(IdVoluntariado > 0)
            {
                response = await _voluntariadoRequisitoService.GetVoluntariadoIdPanelUsuario(IdVoluntariado);
            }
            else
            {
                response = await _voluntariadoRequisitoService.GetVoluntariadoAllPanelUsuario();
            }
            return Ok(response);
        }

        [HttpGet("VoluntariadoPanelOrganizacionID")]
        public async Task<IActionResult> GetVoluntariadoPanelOrg(String IdOrganizacion)
        {
            var voluntariado = await _voluntariadoRequisitoService.GetVoluntariadoPanelOrg(IdOrganizacion);
            return Ok(voluntariado);

        }

        [HttpGet("VoluntariadoEditarDetalleOrganizacion")]
        public async Task<IActionResult> GetVoluntariadoDetalleId(Int32 IdVoluntariado)
        {
            object response;
            var voluntariado = await _voluntariadoRequisitoService.GetVoluntariadoIdPanelOrg(IdVoluntariado);
            return Ok(voluntariado);

        }

        [HttpPost("RegistrarPanelOrg")]
        public async Task<IActionResult> InsertarVoluntariadoRequisitoPanelOrg([FromBody] VoluntariadoInsertarDTO voluntariado)
        {
            try
            {
                await _voluntariadoRequisitoService.InsertarVoluntariadoRequisitoPanelOrg(voluntariado);
                return Ok(new { message = "Registrado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al insertar el voluntariado: {ex.Message}" });
            }
        }

        [HttpPut("ActualizarDatosPanelOrg")]
        public async Task<IActionResult> ActualizarUsuarioOrg([FromBody] VoluntariadoActualizarDTO voluntariado)
        {
            try
            {
                await _voluntariadoRequisitoService.ActualizarVoluntariadoRequisitoPanelOrg(voluntariado);
                return Ok(new { message = "Actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al actualizar los datos del voluntariado: {ex.Message}" });
            }
        }


        [HttpPut("ActualizarEstadoPanelOrg")]
        public async Task<IActionResult> ActualizarUsuario([FromBody] VoluntariadoReqDTO voluntariado)
        {
            try
            {
                await _voluntariadoRequisitoService.ActualizarEstadoVoluntariadoRequisitoPanelOrg(voluntariado);
                return Ok(new { message = "Actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error al actualizar el estado: {ex.Message}" });
            }
        }

    }
}
