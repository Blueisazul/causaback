using System;
using System.Collections.Generic;

namespace CausaViva.Models;

public partial class InscripcionVoluntariado
{
    public int IdInscripcion { get; set; }

    public string? IdUsuario { get; set; }

    public int? IdVoluntariado { get; set; }

    public int? IdEstadoP { get; set; }

    public DateTime? FechaInscripcion { get; set; }

    public bool? Estado { get; set; }

    public virtual EstadoPostulante? IdEstadoPNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual Voluntariado? IdVoluntariadoNavigation { get; set; }
}
