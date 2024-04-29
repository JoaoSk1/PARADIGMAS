using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRABALHO.Classes;
using TRABALHO.Interfaces;

namespace TRABALHO.Relatorios
{
    public class MenosVendidos : IRelatorio
    {
        public List<Produto> Imprimir (List<Produto> produtos)
        {
            return produtos
                .OrderBy(produtos => produtos.QtdVendida)
                .Take(5)
                .ToList();
        }
    }
}
