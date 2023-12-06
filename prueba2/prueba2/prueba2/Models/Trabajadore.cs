using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prueba2.Models;

public partial class Trabajadore
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage =" El tipo de documento es oligatorio")]
    public string? TipoDocumento { get; set; }
    [Required(ErrorMessage = " El numero de documento es oligatorio")]
    public string? NumeroDocumento { get; set; }
    [Required(ErrorMessage = " El nombre es oligatorio")]
    public string? Nombres { get; set; }
    [Required(ErrorMessage = " El sexo es oligatorio")]
    public string? Sexo { get; set; }
    [Required(ErrorMessage = " El departamento es oligatorio")]
    public int? IdDepartamento { get; set; }
    [Required(ErrorMessage = " La provincia es oligatorio")]
    public int? IdProvincia { get; set; }
    [Required(ErrorMessage = " El distrito es oligatorio")]
    public int? IdDistrito { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual Distrito? IdDistritoNavigation { get; set; }

    public virtual Provincium? IdProvinciaNavigation { get; set; }
}
