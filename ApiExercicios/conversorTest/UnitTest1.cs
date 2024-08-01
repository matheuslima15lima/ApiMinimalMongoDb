using conversorTemp;

namespace conversorTest
{
    public class conversorUnitTest1
    {
        [Fact]
        public void Test1()
        {
            var celsius = 4;

            var resultado = Conversor.ConverterCelsiusParaFahrenheit(celsius);

            var resultadoEsperado = 39.2;

            Assert.Equal(resultado, resultadoEsperado);
            
        }
    }
}