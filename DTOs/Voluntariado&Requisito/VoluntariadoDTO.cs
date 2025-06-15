namespace CausaViva.DTOs.Voluntariado_Requisito.Voluntariado
{
    public class VoluntariadoDTO
    {
        public Int32 IdVoluntariado { get; set; }
        public String RazonSocial { get; set; }
        public String TituloPropuesta { get; set; }
        public String DescripcionPropuesta { get; set; }
        public String Direccion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
    }

    public class VoluntariadoDetalleDTO
    {
        public Int32 IdVoluntariado { get; set; }
        public String RazonSocial { get; set; }
        public String TituloPropuesta { get; set; }
        public String DescripcionPropuesta { get; set; }
        public String Direccion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public String DescripcionRequisito { get; set; }
    }

    public class VoluntariadoInsertarDTO
    {
        public String IdOrganizacion { get; set; }
        public String TituloPropuesta { get; set; }
        public String DescripcionPropuesta { get; set; }
        public String Direccion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public String DescripcionRequisito { get; set; }
    }

    public class VoluntariadoActualizarDTO
    {
        public Int32 IdVoluntariado { get; set; }
        public String TituloPropuesta { get; set; }
        public String DescripcionPropuesta { get; set; }
        public String Direccion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public String DescripcionRequisito { get; set; }
        public Boolean Estado { get; set; }
    }

    public class VoluntariadoReqDTO
    {
        public Int32 IdVoluntariado { get; set; }
        public Boolean Estado { get; set; }
    }

}
