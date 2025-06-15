using CausaViva.DTOs.Distrito;
using CausaViva.DTOs.SeguridadLoginUsuario;
using CausaViva.DTOs.Usuario;

namespace CausaViva.Services.SeguridadLoginUsuario
{
    public interface ISeguridadLoginRepository
    {
        Task<SeguridadLoginDTO> GetUsuarioLogin(String IdUsuario);
        Task<SeguridadLoginDTO> GetOrganizacionLogin(String IdUsuario);
    }
}
