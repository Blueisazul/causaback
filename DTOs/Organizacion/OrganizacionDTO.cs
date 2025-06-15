namespace CausaViva.DTOs.Organizacion
{
    public class OrganizacionDTO
    {
        public String IdOrganizacion { get; set; }
        public String RazonSocial { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public Int32 IdDistrito {  get; set; }
        public String NombreDistrito { get; set; }

    }

    public class OrganizacionInsertarDTO() 
    {
        public String IdOrganizacion { get; set; }
        public String RazonSocial { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public Int32 IdDistrito { get; set; }
        public String Contrasenia { get; set; }
    }

    public class OrganizacionActualizarDTO()
    {
        public String IdOrganizacion { get; set; }
        public String RazonSocial { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public Int32 IdDistrito { get; set; }

    }

    public class CambioContraseniaOrg()
    {
        public String IdOrganizacion { get; set; }
        public String Contrasenia { get; set; }
    }

    public class OrgVolReqActualizarEstadoDTO()
    {
        public String IdOrganizacion { get; set; }
        public Boolean Estado { get; set; }
    }
}
