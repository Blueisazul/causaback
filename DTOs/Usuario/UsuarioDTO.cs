
using CausaViva.DTOs.Distrito;

namespace CausaViva.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public String IdUsuario { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public Int32 IdDistrito { get; set; }
        public String NombreDistrito { get; set; }

    }

    public class UsuarioContraseniaDTO
    {
        public String IdUsuario { get; set; }
        public String Contrasenia { get; set; }
    }

    public class UsuarioInsertarDTO
    {
        public String IdUsuario { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public Int32 IdDistrito { get; set; }
        public String Contrasenia { get; set; }

    }

    public class UsuarioActualizarDTO
    {
        public String IdUsuario { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public Int32 IdDistrito { get; set; }
    }

    public class UsuarioEstadoDTO
    {
        public String IdUsuario { get; set; }
        public Boolean Estado {  get; set; }
    }
 }

