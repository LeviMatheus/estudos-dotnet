using Basico_EntityFramework.ValueObject;

namespace Basico_EntityFramework.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Telefone { get; set; }
        public decimal Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public int CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public bool Ativo { get; set; }
        public TipoProduto TipoProduto { get; set; }
    }
}
