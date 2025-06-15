using CausaViva.DTOs.Organizacion;

namespace CausaViva.Services.Organizacion
{
    public interface IOrganizacionService
    {
        Task<IEnumerable<OrganizacionDTO>> GetOrganizacionId(String IdOrganizacion);
        Task InsertarOrganizacionAsync(OrganizacionInsertarDTO organizacion);
        Task ActualizarOrganizacion(OrganizacionActualizarDTO organizacion);
        Task ActualizarEstadoOrgVolReq(OrgVolReqActualizarEstadoDTO organizacion);
        Task CambioContraseniaOrg(CambioContraseniaOrg organizacion);
    }
}
