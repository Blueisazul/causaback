using System;
using System.Collections.Generic;

namespace CausaViva.Models;

public partial class RequisitosVoluntariado
{
    public int IdRequisitos { get; set; }

    public int? IdVoluntariado { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public virtual Voluntariado? IdVoluntariadoNavigation { get; set; }
}
