using Comercio.API.Database;
using Comercio.Models;

namespace Comercio.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly eCommerceContext _db;
        public UsuarioRepository(eCommerceContext db)
        {
            _db = db;
        }
 
        public void Add(Usuario usuario)
        {
            /**
             * Padrão de Projeto "Unit of Works" (usado para modificação no banco)
             * Executa as operações na memória (banco em memória) controlada pelo EF, 
             * que manda depois de estiver ok as operações envia para o banco de dados.
             */
            //Usando Unity of Works
            //Mandar pra memória - EFCore gerencia
            _db.Usuarios.Add(usuario); //ou _db.Add(usuario) -> tipo já enferido no parametro do método
            //Mandar pro banco de dados - Persistência
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Usuarios.Remove(Get(id));
            _db.SaveChanges();
        }

        public List<Usuario> Get()
        {
            /**
             * a ordem faz com que o banco ou o objeto (memória) execute a ação 
             * => _db.Usuarios.OrderBy(x => x.Id).ToList() - Banco de Dados Ordena e objeto Lista disponibiliza
             *  => _db.Usuarios.ToList().OrderBy(x => x.Id)- Objeto Ordena depois do banco de dados disponibilizar os registros
            */
            return _db.Usuarios.OrderBy(u => u.Id).ToList();
        }

        public Usuario Get(int id)
        {
            return _db.Usuarios.Find(id)!; //!NullSaftey = Garante que não virá nulo
        }

        public void Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();
        }
    }
}
