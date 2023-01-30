using Basico_EntityFramework.Configurations;
using Basico_EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Basico_EntityFramework.Data
{
    public class ApplicationContext : DbContext
    {
        //tabelas
        DbSet<Pedido> pedidos { get; set; }

        //sobrescrita da string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb; Inicial Catalog=EFCore; Integrated Security=true");
        }

        //especificar as entidades na criação
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly); aqui puxa automaticamente as configurações sem listar acima
        }
    }
}
