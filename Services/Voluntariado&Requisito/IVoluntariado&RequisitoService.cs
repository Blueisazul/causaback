using CausaViva.DTOs.Voluntariado_Requisito.Voluntariado;

namespace CausaViva.Services.Voluntariado_Requisito
{
    public interface IVoluntariado_RequisitoService
    {
        Task<IEnumerable<VoluntariadoDetalleDTO>> GetVoluntariadoIdPanelUsuario(Int32 IdVoluntariado);
        Task<IEnumerable<VoluntariadoDTO>> GetVoluntariadoAllPanelUsuario();
        Task<IEnumerable<VoluntariadoActualizarDTO>> GetVoluntariadoPanelOrg(String IdOrganizacion);
        Task<IEnumerable<VoluntariadoActualizarDTO>> GetVoluntariadoIdPanelOrg(Int32 IdVoluntariado);
        Task InsertarVoluntariadoRequisitoPanelOrg(VoluntariadoInsertarDTO voluntariado);
        Task ActualizarVoluntariadoRequisitoPanelOrg(VoluntariadoActualizarDTO voluntariado);
        Task ActualizarEstadoVoluntariadoRequisitoPanelOrg(VoluntariadoReqDTO voluntariado);

    }
}
