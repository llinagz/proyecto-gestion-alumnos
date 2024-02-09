using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Profesor
{
    public string Usuario { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
}
