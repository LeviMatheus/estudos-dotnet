using Comercio.Models;

namespace Comercio.API.Repositories
{
    public interface IUsuarioRepository
    {
        /* CRUD - Criar, Ler, Atualizar e Deletar */

        //Listar usuarios
        List<Usuario> get();
        //Buscar um usuário específico
        Usuario Get(int id);
        //Adicionar um usuário
        void Add(Usuario usuario);
        //Atualizar um usuário
        void Update(Usuario usuario);
        //Excluir um usuário
        void Delete(int id);
    }
}
