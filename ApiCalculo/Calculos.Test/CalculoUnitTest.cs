using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculos.Test
{
    public class CalculoUnitTest
    {

        //principio AAA: Agir Organizar e Provar
        [Fact]
        public void SomarDoisNumeros()
        {
            //Organizar (Arrange)
            var n1 = 3.3;
            var n2 = 2.2;
            var valorSomaEsperado = 5.5;

            //Agir (Act)
            var soma = Calculo.Somar(n1, n2);

            //Provar
            Assert.Equal(valorSomaEsperado, soma);
           
        }

        [Fact]
        public void SubtrairDoisNumeros()
        {
            var n1 = 8;
            var n2 = 3;
            var subtracao = Calculo.Subtrair(n1, n2);
            var valorSubtracaoEsperado = 5;
            Assert.Equal(valorSubtracaoEsperado, subtracao);
        }

        [Fact]
        public void MultiplicarDoisNumeros()
        {
            var n1 = 8;
            var n2 = 2;
            var multiplicacao = Calculo.Multiplicar(n1, n2);
            var valorMultiplicacaoEsperado = 16;
            Assert.Equal(valorMultiplicacaoEsperado, multiplicacao);
        }


        [Fact]
        public void DividirDoisNumeros()
        {
            var n1 = 8;
            var n2 = 4;
            var divisao = Calculo.Dividir(n1, n2);
            var valorDivisaoEsperado = 2;
            Assert.Equal(valorDivisaoEsperado, divisao);


        }
    }
}
