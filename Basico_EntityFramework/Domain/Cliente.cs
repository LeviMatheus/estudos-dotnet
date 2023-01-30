using Basico_EntityFramework.ValueObject;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basico_EntityFramework.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; }
        public decimal Telefone { get; set; }
        public decimal Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
