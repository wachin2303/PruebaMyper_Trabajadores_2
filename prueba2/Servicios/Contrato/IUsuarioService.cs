using Microsoft.EntityFrameworkCore;
using prueba2.Models;

namespace prueba2.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
