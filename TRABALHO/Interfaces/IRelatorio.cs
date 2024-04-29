using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRABALHO.Classes;

namespace TRABALHO.Interfaces
{
    public interface IRelatorio
    {
        List<Produto> Imprimir(List<Produto> produtos);
    }
}
