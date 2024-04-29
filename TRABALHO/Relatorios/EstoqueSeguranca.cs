using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRABALHO.Classes;
using TRABALHO.Interfaces;

namespace TRABALHO.Relatorios
{
    public class EstoqueSeguranca : IRelatorio
    {
        public List<Produto> Imprimir(List<Produto> produtos)
        {
            return produtos
            .Where(p => p.Estoque < (p.QtdVendida * 0.33))
            .ToList();
        }
    }
}
