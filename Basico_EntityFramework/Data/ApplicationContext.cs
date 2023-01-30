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
            //método Entity vai informar a entidade no modelo de banco de dados (create) qual entidade eu quero criar
            modelBuilder.Entity<Cliente>(c =>
            {
                c.ToTable("Cliente");//Informa qual o nome da tabela que será criada
                c.HasKey(c=> c.Id);//Informa a chave primária da entidade
                c.Property(c => c.Nome).HasColumnType("VARCHAR(80)").IsRequired();//Configura qual o tipo de dados criado na tabela, e isrequired para não ser nulo
                c.Property(c => c.Telefone).HasColumnType("CHAR(11)").IsRequired();
                c.Property(c => c.Cep).HasColumnType("CHAR(8)").IsRequired();
                c.Property(c => c.Estado).HasColumnType("CHAR(15)").IsRequired();
                c.Property(c => c.Cidade).HasMaxLength(60).IsRequired();

                // c.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone");//Criando o índice da base de dados
            });

            modelBuilder.Entity<Produto>(p =>
            {
                p.ToTable("Produto");
                p.HasKey(p => p.Id);
                p.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(80)").IsRequired();
                p.Property(p => p.Descricao).HasColumnType("CHAR(11)").IsRequired();
                p.Property(p => p.Valor).IsRequired();

                //p.HasMany(p => p.Itens).WithOne(p => p.Pedido).OnDelete(DeleteBehavior.Cascade);//criando relação de muitos para 1
                                                                //esse código acima informa que  vai deletar os itens do pedido caso um produto seja deletado
            });

            modelBuilder.Entity<Pedido>(p =>
            {
                p.ToTable("Pedido");
                p.HasKey(p => p.Id);
                p.Property(p => p.StatusPedido).HasConversion<string>();//convertendo enum para string
                p.Property(p => p.TipoFrete).HasConversion<string>();//convertendo enum para string
                p.Property(p => p.Observacao).HasColumnType("CHAR(50)").IsRequired();
            });

            modelBuilder.Entity<PedidoItem>(p =>
            {
                p.ToTable("PedidoItem");
                p.HasKey(p => p.Id);
                p.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();//por padrão o valor 1
                p.Property(p => p.Valor).IsRequired();
                p.Property(p => p.Desconto).IsRequired();
            });
        }
    }
}
