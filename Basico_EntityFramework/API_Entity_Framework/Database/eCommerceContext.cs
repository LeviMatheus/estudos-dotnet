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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Nome = "Moda"},
                new Departamento { Id = 2, Nome = "Mercado"},
                new Departamento { Id = 3, Nome = "Móveis" },
                new Departamento { Id = 4, Nome = "Înformática" },
                new Departamento { Id = 5, Nome = "Eletrodomésticos" },
                new Departamento { Id = 6, Nome = "Eletroportáteis" },
                new Departamento { Id = 7, Nome = "Beleza" }
            );
        }

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
