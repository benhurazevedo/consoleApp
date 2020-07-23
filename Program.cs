using System;
using consoleApp.Models;
using System.Collections.Generic;
using consoleApp.Services;

namespace consoleApp
{
    class Program
    {
        private static DbService dbService;
        static void Main(string[] args)
        {
            String opcao;
            dbService = new DbService();
            do{
                Console.Clear();
                Console.WriteLine("Gerenciador de Produtos");
                Console.WriteLine("#######################");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Inserir produto");
                Console.WriteLine("2 - exibir produtos");
                Console.WriteLine("3 - Apagar produto");
                Console.WriteLine("4 - Sair");
                Console.Write("Digite a opção desejada: ");
                opcao = Console.ReadLine();
                switch(opcao){
                    case "1":
                        exibeInsereProduto();
                        break;
                    case "2":
                        exibeProdutos();
                        break;
                    case "3":
                        exibeTelaApagar();
                        break;
                    case "4":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção Inválida;");
                        Console.Write("Digite uma tecla para continuar.");
                        Console.ReadLine();
                        break;
                }
            } while(true);
        }
        public static void exibeInsereProduto()
        {
            double preco = -1;
            Produtos produto = new Produtos();
            Console.Clear();
            Console.Write("Digite o nome do produto:");
            produto.Nome = Console.ReadLine();
            Console.Write("Digite a Categoria:");
            produto.Categoria = Console.ReadLine();
            while(preco == -1)
            {
                Console.Write("Digite o preco:");
                var strPreco = Console.ReadLine();
                if(!Double.TryParse(strPreco, out preco))
                {
                    Console.WriteLine("Preço inválido!");
                    preco = -1;
                    continue;
                }
                produto.Preco = preco;
                break;
            }
            if(dbService.inserirProduto(produto))
            {
                Console.WriteLine("Produto incluído com sucesso!");
            }
            else 
            {
                Console.WriteLine("Falha na inclusao do produto!");
            }
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
        public static void exibeProdutos()
        {
            Console.Clear();
            List<Produtos> listaProdutos = dbService.listarProdutos();
            if (listaProdutos.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados.");
                Console.Write("Pressione ENTER para continuar...");
                Console.ReadLine();
                return;
            }
            foreach(Produtos produto in listaProdutos)
            {
                Console.WriteLine("");
                Console.WriteLine("Codigo: " + produto.Id.ToString());
                Console.WriteLine("Nome: " + produto.Nome);
                Console.WriteLine("Categoria: " + produto.Categoria);
                Console.WriteLine("Preço: " + produto.Preco.ToString());
                Console.Write("Digite ENTER para prosseguir...");
                Console.ReadLine();
            }
        }
        public static void exibeTelaApagar()
        {
            string codigoProduto = null;
            int codigo;
            Produtos produto;
            Console.Clear();
            Console.Write("Digite o codigo do produto a ser excluido: ");
            codigoProduto = Console.ReadLine();
            if(!Int32.TryParse(codigoProduto, out codigo))
            {
                Console.WriteLine("Codigo inválido.");
                Console.Write("Digite ENTER para prosseguir...");
                Console.ReadLine();
                return;
            }
            produto = dbService.getProduto(codigo);
            if(produto == null)
            {
                Console.WriteLine("Codigo inválido.");
                Console.Write("Digite ENTER para prosseguir...");
                Console.ReadLine();
                return;
            }
            if(dbService.excluirProduto(produto.Id))
            {
                Console.WriteLine("Produto excluído.");
            }
            else
            {
                Console.WriteLine("Não foi possível excluir o produto.");
            }
            Console.Write("Digite ENTER para prosseguir...");
            Console.ReadLine();
        }
    }
}
