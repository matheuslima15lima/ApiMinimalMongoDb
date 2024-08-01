using livros;
using System.Security.Cryptography.X509Certificates;

namespace TestProject1
{
    public class livroUnitTest
    {
        [Fact]
        public void adicionarLivro()
        {
            List<Livro> listaLivros = [];

            Livro livro = new Livro();
            livro.Nome = "Pinoquio";
            livro.Genero = "Conto";

            listaLivros.Add(livro);

            // var genero = livro.Genero;

            //var generoEsperado = "Terror";

            Assert.Contains(livro, listaLivros);

            //if (genero == generoEsperado)
            //{
            //    //listaLivros.Add(livro);
            //}
            


        }
    }
}