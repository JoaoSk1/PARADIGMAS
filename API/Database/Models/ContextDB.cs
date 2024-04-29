using API.Database.Parser;
using System.Collections.Generic;
using System.IO;

namespace API.Database.Models
{
    public class ContextDB
    {

        private readonly string _dataset;
        private readonly List<Produto> _produtos;
        public ContextDB() 
        { 
             _dataset = File.ReadAllText("Dataset.csv");
            _produtos = ProdutoParser.ConverterLista(_dataset);
        }
        public List<Produto> Produtos => _produtos;

        public IEnumerable<object> Produto { get; internal set; }
    }
}
