using Basico_EntityFramework.Domain;
using Basico_EntityFramework.ValueObject;

namespace Basico_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InserirDados();
        }

        private static void InserirDados()
        {
            var Produto = new Produto
            {
                Descricao = "Schwepps Lata",
                Valor = 6,
                TipoProduto = TipoProduto.Embalagem,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();
            db.Set<Produto>().Add(Produto);

            var register = db.SaveChanges();
            Console.WriteLine($"Total de registro(s): {register}");
        }
    }
}