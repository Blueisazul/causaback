using System;
using System.Collections.Generic;

namespace CausaViva.Models;

public partial class Voluntariado
{
    public int IdVoluntariado { get; set; }

    public string? IdOrganizacion { get; set; }

    public string? TituloPropuesta { get; set; }

    public string? DescripcionPropuesta { get; set; }

    public string? Direccion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFinal { get; set; }

    public bool? Estado { get; set; }

    public virtual Organizacion? IdOrganizacionNavigation { get; set; }

    public virtual ICollection<InscripcionVoluntariado> InscripcionVoluntariados { get; set; } = new List<InscripcionVoluntariado>();

    public virtual ICollection<RequisitosVoluntariado> RequisitosVoluntariados { get; set; } = new List<RequisitosVoluntariado>();
}
