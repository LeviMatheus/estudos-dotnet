using Microsoft.EntityFrameworkCore;

namespace Comercio.API.Database
{
    public class eCommerceContext : DbContext
    {
        //Criando um construtor para receber a string de conexão
        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(options)
        {
        }

        //criando propriedades para mapeamento
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        #region Conexão sem distinção de ambientes de execução
        /* 
         Conexão sem distinção de ambientes de execução
         */

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Indicando qual banco vai ser utilizado (SqlServer)
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eCommerce;Integrated Security=True");
        }*/
        #endregion
    }
}
