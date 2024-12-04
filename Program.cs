using System;
using System.Collections.Generic;

class Program
{
    static List<Produto> produtos = new List<Produto>();
    static int idCounter = 1;

    static void Main(string[] args)
    {
        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarProduto();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "3":
                    AtualizarProduto();
                    break;
                case "4":
                    ExcluirProduto();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\nMenu de CRUD - Cadastro de Produtos");
        Console.WriteLine("1. Adicionar Produto");
        Console.WriteLine("2. Listar Produtos");
        Console.WriteLine("3. Atualizar Produto");
        Console.WriteLine("4. Excluir Produto");
        Console.WriteLine("5. Sair");
        Console.Write("Escolha uma opção: ");
    }

    static void AdicionarProduto()
    {
        Console.WriteLine("\nDigite os detalhes do novo produto:");

        Produto produto = new Produto();
        produto.ID = idCounter++;
        Console.Write("Nome: ");
        produto.Nome = Console.ReadLine();
        Console.Write("Preço: ");
        produto.Preco = decimal.Parse(Console.ReadLine());
        Console.Write("Categoria: ");
        produto.Categoria = Console.ReadLine();
        Console.Write("Quantidade: ");
        produto.Quantidade = int.Parse(Console.ReadLine());

        produtos.Add(produto);
        Console.WriteLine("Produto adicionado com sucesso!");
    }

    static void ListarProdutos()
    {
        Console.WriteLine("\nLista de Produtos:");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"ID: {produto.ID}, Nome: {produto.Nome}, Preço: {produto.Preco:C}, Categoria: {produto.Categoria}, Quantidade: {produto.Quantidade}");
        }
    }

    static void AtualizarProduto()
    {
        Console.Write("\nDigite o ID do produto a ser atualizado: ");
        int id = int.Parse(Console.ReadLine());
        Produto produto = produtos.Find(p => p.ID == id);

        if (produto != null)
        {
            Console.WriteLine("Produto encontrado. Digite os novos dados.");
            Console.Write("Nome: ");
            produto.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            produto.Preco = decimal.Parse(Console.ReadLine());
            Console.Write("Categoria: ");
            produto.Categoria = Console.ReadLine();
            Console.Write("Quantidade: ");
            produto.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Produto atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }

    static void ExcluirProduto()
    {
        Console.Write("\nDigite o ID do produto a ser excluído: ");
        int id = int.Parse(Console.ReadLine());
        Produto produto = produtos.Find(p => p.ID == id);

        if (produto != null)
        {
            produtos.Remove(produto);
            Console.WriteLine("Produto excluído com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }
}