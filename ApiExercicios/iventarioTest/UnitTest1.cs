using Inventario;

namespace iventarioTest
{
    public class UnitTest1
    {
        [Fact]
        public void IventarioUnitTest()
        {
            Produto produtoI = new Produto { Nome = "Produto X", Quantidade = 5 };
            //produtoI.Nome = "Exemplo de Produto";
            //produtoI.Quantidade = 1;
            Iventario.AdicionarProduto(produtoI);

            Assert.Equal(5, produtoI.Quantidade);
        }

        //bool existe = Iventario.ProdutoExiste(produtoI);
       
    }
}