using System;
using System.Collections.Generic;

namespace CausaViva.Models;

public partial class Usuario
{
    public string IdUsuario { get; set; } = null!;

    public int? IdRol { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public int? IdDistrito { get; set; }

    public string? Contrasenia { get; set; }

    public bool? Estado { get; set; }

    public virtual Distrito? IdDistritoNavigation { get; set; }

    public virtual Roles? IdRolNavigation { get; set; }

    public virtual ICollection<InscripcionVoluntariado> InscripcionVoluntariados { get; set; } = new List<InscripcionVoluntariado>();
}
