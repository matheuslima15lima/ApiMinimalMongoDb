using email;

namespace emailTest
{
    public class emailUnitTest
    {
        [Fact]
        public void Test1()
        {
            var emailNome = "email@.com";

            var valorEsperado = true;

            var verficaEmail = Email.verificarEmail(emailNome);

            Assert.Equal(valorEsperado, verficaEmail);
        }
    }
}