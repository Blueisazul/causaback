using System;
using System.Collections.Generic;

namespace CausaViva.Models;

public partial class Distrito
{
    public int IdDistrito { get; set; }

    public string? NombreDistrito { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Organizacion> Organizacions { get; set; } = new List<Organizacion>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
