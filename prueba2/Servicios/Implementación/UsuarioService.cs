using Microsoft.EntityFrameworkCore;
using prueba2.Models;
using prueba2.Servicios.Contrato;

namespace prueba2.Servicios.Implementación
{
    public class UsuarioService : IUsuarioService
    {
        private readonly TrabajadoresPruebaContext _dbcontext;
        public UsuarioService(TrabajadoresPruebaContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Usuario> GetUsuarios(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbcontext.Usuarios.Where(u=>u.Correo==correo && u.Clave==clave)
                .FirstOrDefaultAsync();
            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbcontext.Usuarios.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return modelo;
        }
    }
}
