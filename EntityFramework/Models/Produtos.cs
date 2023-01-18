using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usando_EntityFramework.Models
{
    public class Produtos
    {
        [Key]//indicar que esta variável é uma PK
        public int Codigo_do_produto { get; set; }
        public string? Nome_do_produto { get; private set; } = null!;//null! sinalizando que essa coluna pode ser vazia
        public string? Embalagem_do_produto { get; private set; } = null!;
        public string? Tamanho_do_produto { get; private set; } = null!; 
        public string? Sabor_do_produto { get; private set; } = null!; 
        public decimal Preco_do_produto { get; private set; }
    }
}
