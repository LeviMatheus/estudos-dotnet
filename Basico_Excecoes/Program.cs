using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                ContaCorrente vazia = new ContaCorrente(0, 525);
            }catch(ArgumentException ex){
                Console.WriteLine($"Erro no parâmetro {ex.ParamName}");
                Console.WriteLine($"Exceção {ex.Message}");
            }
            //ContaCorrente conta = new ContaCorrente(1234,1234123);
            Console.WriteLine(ContaCorrente.TaxaOperacao);
            Console.ReadLine();
        }
    }
}
