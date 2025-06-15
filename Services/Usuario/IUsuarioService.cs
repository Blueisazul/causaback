using CausaViva.DTOs.Usuario;

namespace CausaViva.Services.Usuario
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetUsuarioId(String IdUsuario);
        Task InsertarUsuarioAsync (UsuarioInsertarDTO usuario);
        Task ActualizarUsuario(UsuarioActualizarDTO usuario);
        Task ActualizarEstadoUsuario(UsuarioEstadoDTO usuario);
        Task CambioContrasenia(UsuarioContraseniaDTO usuario);

    }
}
