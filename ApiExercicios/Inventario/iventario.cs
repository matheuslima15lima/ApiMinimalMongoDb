using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    public static class Iventario
    {
        private static List<Produto> lista = new List<Produto>();
        public static void AdicionarProduto(Produto produto)
        {
            Produto produtoAdicionado = new Produto();

            lista.Add(produtoAdicionado);

            //if (produto.Contains(produtoAdicionado))
            //{
            //     produtoAdicionado.Quantidade ++;
            //}

            //else
            //{
            //    produto.Add(produtoAdicionado);
            //}
        }

        public static int retornoQuantidade(Produto produto)
        {
            //List<Produto> lista = new List<Produto>();

            if (lista.Contains(produto))
            {
                produto.Quantidade++;
                return produto.Quantidade;
            }  

            else
            {
                return 0;
            }
        }

        public static bool ProdutoExiste(Produto produto)
        {
            if (!lista.Contains(produto)) { return true; }
            else { return false; }
        }
    }
}
