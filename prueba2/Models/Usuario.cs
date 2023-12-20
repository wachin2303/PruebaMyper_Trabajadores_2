using System.ComponentModel.DataAnnotations;

namespace prueba2.Models
{
    public partial class Usuario
    {

        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage ="Nombre es obligatorio")]
        public string? NombreUsuario { get; set; }
        [Required(ErrorMessage = "Correo es obligatorio")]
        public string? Correo {  get; set; }
        [Required(ErrorMessage = "Clave es obligatorio")]
        public string? Clave { get; set; }

    }
}
