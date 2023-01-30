using Basico_EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basico_EntityFramework.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StatusPedido).HasConversion<string>();//convertendo enum para string
            builder.Property(p => p.TipoFrete).HasConversion<string>();//convertendo enum para string
            builder.Property(p => p.Observacao).HasColumnType("CHAR(50)").IsRequired();
        }
    }
}
