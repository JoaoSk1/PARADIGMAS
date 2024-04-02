using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TRABALHO.Classes;

var dataset = File.ReadAllText("..\\..\\..\\Dataset.csv");

var list = ProdutoParser.ConverterLista(dataset);
while (true)
{
    Console.WriteLine("MENU");
    Console.WriteLine("1 - Produtos Mais Vendidos");
    Console.WriteLine("2 - Produtos Com Mais Estoque");
    Console.WriteLine("3 - Categoria Mais Vendida");
    Console.WriteLine("4 - Produtos Menos Vendidos");
    Console.WriteLine("5 - Estoque de segurança");
    Console.WriteLine("6 - Excesso de estoque");
    Console.WriteLine("7 - Média de preço por categoria");
    Console.WriteLine("9 - Sair");

    if (!int.TryParse(Console.ReadLine(), out int op))
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
        continue;
    }
    switch (op)
    {
        case 1:
            Console.Clear();
            P_MaisVendido(list);
            Console.WriteLine("\n");
            break;
        case 2:
            Console.Clear();
            P_MaisEstoque(list);
            Console.WriteLine("\n");
            break;
        case 3:
            Console.Clear();
            C_MaisVendida(list);
            Console.WriteLine("\n");
            break;
        case 4:
            Console.Clear();
            P_MenosVendido(list);
            Console.WriteLine("\n");
            break;
        case 5:
            Console.Clear();
            E_EstoqueSeguranca(list);
            Console.WriteLine("\n");
            break;
        case 6:
            Console.Clear();
            E_Estoque(list);
            Console.WriteLine("\n");
            break;
        case 7:
            Console.Clear();
            C_Media(list);
            Console.WriteLine("\n");
            break;
        case 9:
            Console.Clear();
            Console.WriteLine("Saindo do programa.");
            Console.WriteLine("\n");
            return;
        default:
            Console.Clear();
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}

static void P_MaisVendido(List<Produto> produtos)
{
    var P_Ordenado = produtos.OrderByDescending(produtos => produtos.QtdVendida).Take(5);
    var I = 1;
    Console.WriteLine("\u001B[4mTop 5 - Produtos Mais Vendidos\u001B[24m");
    foreach (var produto in P_Ordenado)
    {
        Console.WriteLine($"Top {I}: Código - {produto.Codigo} - {produto.Descricao} - {produto.QtdVendida} Unidades Vendidas.");
        I++;
    }
}
static void P_MenosVendido(List<Produto> produtos)
{
    var P_Ordenado = produtos.OrderBy(produtos => produtos.QtdVendida).Take(5);
    var I = 1;
    Console.WriteLine("\u001B[4mTop 5 - Produtos Menos Vendidos\u001B[24m");
    foreach (var produto in P_Ordenado)
    {
        Console.WriteLine($"Top {I}: Código - {produto.Codigo} - {produto.Descricao} - {produto.QtdVendida} Unidades Vendidas.");
        I++;
    }
}
static void P_MaisEstoque(List<Produto> produtos)
{
    var P_Ordenado = produtos.OrderByDescending(produtos => produtos.Estoque).Take(3);
    var I = 1;
    Console.WriteLine("\u001B[4mTop 3 - Produtos Com Mais Estoque\u001B[24m");
    foreach (var produto in P_Ordenado)
    {
        Console.WriteLine($"Top {I}: Código - {produto.Codigo} - {produto.Descricao} - {produto.Estoque} Unidades em Estoque.");
        I++;
    }
}
static void C_MaisVendida(List<Produto> produtos)
{
    var C_Ordenado = produtos.GroupBy(produtos => produtos.Categoria).OrderByDescending(produtos => produtos.Sum(produtos => produtos.QtdVendida)).First().Key;
    Console.WriteLine($"Categoria: {C_Ordenado}");
}

static void C_Media(List<Produto> produtos)
{
    var Media = produtos.GroupBy(produtos => produtos.Categoria).Select(groupBy => new { Categoria = groupBy.Key, PrecoMedio = groupBy.Average(produtos => produtos.Preco) });
    foreach (var item in Media)
    {
        Console.WriteLine($"Categoria: {item.Categoria} - Preço médio: {item.PrecoMedio:n2}");
    }
}
static void E_Estoque(List<Produto> produtos)
{
    var ExcessoEstoque = produtos.Where(produtos => produtos.Estoque >= (produtos.QtdVendida * 3));

    Console.WriteLine("\u001B[4mExcesso de estoque\u001B[24m");

    foreach (var produto in ExcessoEstoque)
    {
        Console.WriteLine($"Código: {produto.Codigo}, Descrição: {produto.Descricao}, Estoque: {produto.Estoque}");
    }
}
static void E_EstoqueSeguranca(List<Produto> produtos)
{
    var EstoqueSeguranca = produtos.Where(produtos => produtos.Estoque < (produtos.QtdVendida * 0.33));

    Console.WriteLine("\u001B[4mEstoque de Segurança\u001B[24m");

    foreach (var produto in EstoqueSeguranca)
    {
        Console.WriteLine($"Código: {produto.Codigo} - {produto.Descricao} - {produto.Estoque} em Estoque");
    }
}
