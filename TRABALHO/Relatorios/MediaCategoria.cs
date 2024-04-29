using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRABALHO.Classes;
using TRABALHO.Interfaces;

namespace TRABALHO.Relatorios
{
    public class MediaCategoria : IRelatorio
    {
        public void Imprimir(List<Produto> produtos)
        {
            var Media = produtos.GroupBy(produtos => produtos.Categoria).Select(groupBy => new { Categoria = groupBy.Key, PrecoMedio = groupBy.Average(produtos => produtos.Preco) });

            foreach (var item in Media)
            {
                Console.WriteLine($"Categoria: {item.Categoria} - Preço médio: {item.PrecoMedio:n2}");
            }
        }
    }
}
