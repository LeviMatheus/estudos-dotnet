using Basico_EntityFramework.ValueObject;

namespace Basico_EntityFramework.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime FinalizadoEm { get; set;}
        public TipoFrete TipoFrete { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public string Observacao { get; set; }
        public ICollection<PedidoItem> Itens { get; set; }
        public DateTime FinalizandoEm { get; internal set; }
        public string Nome { get; internal set; }
    }
}
