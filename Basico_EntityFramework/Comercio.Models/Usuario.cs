using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.Models
{
    /*
     * EFCore + Migration:
    */ 
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Sexo { get; set; }
        public string? RG { get; set; }
        public string CPF { get; set; } = null!;
        public string? NomeMae { get; set; }
        public string? SituacaoCadastro { get; set; }
        public DateTimeOffset DataCadastro { get; set; }//Datetime com localização

        //Relacionamento entre as classes
        public Contato? Contato { get; set;}
        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public ICollection<Departamento>? Departamentos { get; set; }
    }
}
