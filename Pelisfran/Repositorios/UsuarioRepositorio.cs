using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System.Linq;

namespace Pelisfran.Repositorios
{
    public class UsuarioRepositorio
    {
        private PelisFranDBContexto _db;

        public UsuarioRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();
        }

        public bool ExisteEmail(string email)
        {
            return _db.Usuarios.Where(u => u.Email == email).FirstOrDefault() != null ? true : false;
        }
    }
}