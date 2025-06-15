using System;
using System.Collections.Generic;

namespace CausaViva.Models;

public partial class Organizacion
{
    public string IdOrganizacion { get; set; } = null!;

    public int? IdRol { get; set; }

    public string? RazonSocial { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public int? IdDistrito { get; set; }

    public string? Contrasenia { get; set; }

    public bool? Estado { get; set; }

    public virtual Distrito? IdDistritoNavigation { get; set; }

    public virtual Roles? IdRolNavigation { get; set; }

    public virtual ICollection<Voluntariado> Voluntariados { get; set; } = new List<Voluntariado>();
}
