using CausaViva.DTOs.InscripcionVoluntariado;
using CausaViva.DTOs.Organizacion;

namespace CausaViva.Services.InscripcionVoluntariado
{
    public interface IInscripcionVoluntariado
    {
        Task InscripcionVol(InscripcionVoluntariadoDTO inscripcion);
        Task<IEnumerable<InscripcionVolDatosPanelUsuarioDTO>> GetInsVolPanelUsuario(String IdUsuario);
        Task<IEnumerable<InscripcionVolDatosPanelOrganizacionDTO>> GetInsVolPanelOrganizacion(String IdOrganizacion);
        Task ActualizarEstadoInscripcion(InscripcionVolActualizarDTO inscripcion);
    }

}
