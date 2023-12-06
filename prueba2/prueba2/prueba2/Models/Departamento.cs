using System;
using System.Collections.Generic;

namespace prueba2.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string? NombreDepartamento { get; set; }

    public virtual ICollection<Provincium> Provincia { get; } = new List<Provincium>();

    public virtual ICollection<Trabajadore> Trabajadores { get; } = new List<Trabajadore>();
}
