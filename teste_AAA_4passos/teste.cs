namespace Teste_AAA;

public class teste
{
    [Fact]
    public void testarCasos()
    {
        EstruturaAAA();
        Estrutura4passos();
    }

    public void EstruturaAAA()
    {
        //Arrange - Preparar
        var cliente_cpf = "111.111.111-00";
        var esperado = false;
        //Act - Agir
        var resultado = cpf.validaCPF(cliente_cpf);
        //Asset - Validar, Espero que ele seja falso
        Assert.Equal(esperado,resultado);
    }

    public void Estrutura4passos()
    {
        //Setup - Preparar
        var cliente_cpf = "346.184.320-20";
        var esperado = true;
        //Exercise - (Agir)
        var resultado = cpf.validaCPF(cliente_cpf);
        //Verify - Validar
        Assert.Equal(esperado,resultado);
        //Teardown - destruir/resetar
        cliente_cpf = null;
    }
}