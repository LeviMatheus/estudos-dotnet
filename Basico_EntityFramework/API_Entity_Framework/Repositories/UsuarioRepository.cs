using Comercio.Models;

namespace Comercio.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //criando a lista de usuários
        public static List<Usuario> _db = new List<Usuario>();
        public void Add(Usuario usuario)
        {
            _db.Add(usuario);
        }

        public void Delete(int id)
        {
            _db.Remove(Get(id));
        }

        public List<Usuario> get()
        {
            return _db;
        }

        public Usuario Get(int id)
        {
            return _db.Find(u => u.Id == id)!;
        }

        public void Update(Usuario usuario)
        {
            _db.Remove(Get(usuario.Id));
            _db.Add(usuario);
        }
    }
}
