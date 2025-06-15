using System;
using System.Collections.Generic;

namespace CausaViva.Models;

public partial class Roles
{
    public int IdRol { get; set; }

    public string? DescripcionRol { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Organizacion> Organizacions { get; set; } = new List<Organizacion>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
