using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRABALHO.Classes;
using TRABALHO.Interfaces;

namespace TRABALHO.Relatorios
{
    public class ProdutoComMaisEstoque : IRelatorio
    {
        public List<Produto> Imprimir(List<Produto> produtos)
        {
            return produtos
                .OrderByDescending(produtos => produtos.Estoque)
                .Take(3)
                .ToList();
        }
    }
}
