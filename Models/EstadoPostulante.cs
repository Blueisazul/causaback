using System;
using System.Collections.Generic;

namespace CausaViva.Models;

public partial class EstadoPostulante
{
    public int IdEstadoP { get; set; }

    public string? EstadoP { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<InscripcionVoluntariado> InscripcionVoluntariados { get; set; } = new List<InscripcionVoluntariado>();
}
