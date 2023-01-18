using Usando_EntityFramework.Data;
using Usando_EntityFramework.Models;

namespace Usando_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Exemplo de instancia do contexto
            using (var db = new ProdutosContext())
            {
                //abrir conexão com o banco
                db.Database.EnsureCreated();//Cria o banco de dados
                //Ficar atento a Migrations (Toda estrutura do banco), primeiro ver como o EF modelou o banco pra depois criar o banco
                //No terminal rodar: dotnet ef migrations add Nome
                //O comando de cima vai criar uma pasta Migrations no projeto com classes inicial, snapshot e talvez uma design
                //Para atualizar a base de dados rodar
                //dotnet ef database update
            }
        }
    }
}