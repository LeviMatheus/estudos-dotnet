using ByteBank_ADM.Funcionarios;
using ByteBank_ADM.Utilitario;
using System.Runtime.CompilerServices;
void CalcularBonificacao()
{
    GerenciadorBonificacao gerenciador = new GerenciadorBonificacao();

    Designer sange = new Designer("123456");
    sange.Nome = "Sange G";

    Diretor guerreiro = new Diretor("987654");
    guerreiro.Nome = "Sange S";

    Auxiliar matheus = new Auxiliar("123123");
    matheus.Nome = "Matheus L";

    GerenteContas levi = new GerenteContas("456456");
    levi.Nome = "Levi M";

    gerenciador.Registrar(sange);
    gerenciador.Registrar(guerreiro);
    gerenciador.Registrar(matheus);
    gerenciador.Registrar(levi);

    Console.WriteLine($"Total de Bonificação {gerenciador.TotalDeBonificacao}");
}

//public static void Main(string[] args)
//{
//    #region
//    //Funcionario levi = new Funcionario("123456789",2400);
//    //levi.Nome = "Levi Matheus";
//    //Console.WriteLine($"Funcionário: {levi.Nome}, bonificação: {levi.GetBonificacao()}");

//    //Diretor matheus = new Diretor("987654321");
//    //matheus.Nome = "Matheus Martins";
//    //Console.WriteLine($"Diretor: {matheus.Nome}, bonificação: {matheus.GetBonificacao()}");

//    //GerenciadorBonificacao gerenciador = new GerenciadorBonificacao();
//    //gerenciador.Registrar(levi);
//    //gerenciador.Registrar(matheus);

//    //Console.WriteLine("Total de bonificações: " + gerenciador.TotalDeBonificacao);
//    //Console.WriteLine("Total de funcionários: " + Funcionario.TotalDeFuncionarios);

//    //levi.AumentarSalario();
//    //matheus.AumentarSalario();

//    //Console.WriteLine($"Novo Salário {levi.Nome} é {levi.Salario}");
//    //Console.WriteLine($"Novo Salário {matheus.Nome} é {matheus.Salario}");
//    #endregion
//}

CalcularBonificacao();