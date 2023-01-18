namespace Calculadora.Tests
{
    public class CalculadoraTest
    {
        [Fact]
        public void Somar()
        {
            Assert.Equal(20, Calculadora.Somar(10, 10));
        }

        [Fact]
        public void Subtrair()
        {
            Assert.Equal(0, Calculadora.Subtrair(10, 10));
        }

        [Fact]
        public void Multiplicar()
        {
            Assert.Equal(100, Calculadora.Multiplicar(10, 10));
        }

        [Fact]
        public void Dividir()
        {
            Assert.Equal(1, Calculadora.Dividir(10, 10));
        }
    }
}