using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_ADM.Funcionarios
{
    public class GerenteContas : Funcionario
    {
        public override double GetBonificacao()
        {
            return this.Salario * 0.25;
        }

        public GerenteContas(string cpf) : base(cpf, 4000)
        {

        }

        public override void AumentarSalario()
        {
            this.Salario *= 1.05;
        }
    }
}
