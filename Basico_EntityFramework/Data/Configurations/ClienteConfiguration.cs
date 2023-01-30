using Basico_EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Basico_EntityFramework.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");//Informa qual o nome da tabela que será criada
            builder.HasKey(c => c.Id);//Informa a chave primária da entidade
            builder.Property(c => c.Nome).HasColumnType("VARCHAR(80)").IsRequired();//Configura qual o tipo de dados criado na tabela, e isrequired para não ser nulo
            builder.Property(c => c.Telefone).HasColumnType("CHAR(11)").IsRequired();
            builder.Property(c => c.Cep).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(c => c.Estado).HasColumnType("CHAR(15)").IsRequired();
            builder.Property(c => c.Cidade).HasMaxLength(60).IsRequired();
        }
    }
}
