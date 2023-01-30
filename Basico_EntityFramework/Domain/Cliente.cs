using Basico_EntityFramework.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basico_EntityFramework.Domain
{
    [Table("Clientes")]//Mapeamento do nome da tabela de dados
    public class Cliente
    {
        [Key]//informa que o atributo é uma chave primária
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }
        [Required]//informa que o atributo não pode ser nulo
        public string Nome { get; set; }
        [Column("Phone")]//Substituir o nome no banco de dados
        public decimal Telefone { get; set; }
        public decimal Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
