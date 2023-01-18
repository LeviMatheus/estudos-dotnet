using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usando_EntityFramework.Models;
using Microsoft.Extensions.Configuration;

namespace Usando_EntityFramework.Data
{
    public class ProdutosContext : DbContext //Necessário extender do tipo DbContext para poder ter acesso ao métodos do contexto de dados
    {
        public DbSet<Produtos> Produtos { get; set; } = null!;//Declarando a tabela de produtos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//sobrecarga do método de configuração
        {
            //optionsBuilder.UseSqlServer(@"");//String de conexão
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MinhaVenda;Trusted_Connection = True;");//String de conexão
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//Sobrecarga do método de modelagem
        {
            //Passa configurações quando o modelo for criado
            //Consiga modificar o nome da tabela, "Produto" no singular
            modelBuilder.Entity<Produtos>()
                .ToTable("Produto");
            //Consiga modificar informando que a chave primária é o código do produto
            modelBuilder.Entity<Produtos>()
                .HasKey(p => p.Codigo_do_produto);
            //Exemplo, modificar o tipo da coluna
            modelBuilder.Entity<Produtos>()
                .Property(p => p.Nome_do_produto)
                .HasColumnType("varchar(200)");
        }
    }
}
