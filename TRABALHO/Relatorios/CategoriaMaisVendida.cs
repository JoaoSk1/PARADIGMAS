using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRABALHO.Classes;
using TRABALHO.Interfaces;

namespace TRABALHO.Relatorios
{
    public class CategoriaMaisVendida : IRelatorio
    {
        public void Imprimir(List<Produto> produtos)
        {
            var C_Ordenado = produtos.GroupBy(produtos => produtos.Categoria).OrderByDescending(produtos => produtos.Sum(produtos => produtos.QtdVendida)).First().Key;

            Console.WriteLine($"Categoria: {C_Ordenado}");
        }
    }
}
