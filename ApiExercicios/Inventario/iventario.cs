using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    public static class Iventario
    {
        public static void AdicionarProduto(List<Produto> produto)
        {
            Produto produtoAdicionado = new Produto();
            produtoAdicionado.Quantidade = 0;
            

            if (produto.Contains(produtoAdicionado))
            {
                 produtoAdicionado.Quantidade ++;
            }

            else
            {
                produto.Add(produtoAdicionado);
            }
        }
    }
}
