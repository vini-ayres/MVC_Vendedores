using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Vendedores
{
    class Program
    {
        static void Main(string[] args)
        {
            Vendedores vendedores = new Vendedores(10);
            int opcao;

            do
            {
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar vendedor");
                Console.WriteLine("2. Consultar vendedor");
                Console.WriteLine("3. Excluir vendedor");
                Console.WriteLine("4. Registrar venda");
                Console.WriteLine("5. Listar vendedores");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Informe o ID do vendedor: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Informe o nome do vendedor: ");
                        string nome = Console.ReadLine();
                        Console.Write("Informe a porcentagem de comissão: ");
                        double percComissao = double.Parse(Console.ReadLine());
                        Vendedor novoVendedor = new Vendedor(id, nome, percComissao);
                        if (vendedores.AddVendedor(novoVendedor))
                        {
                            Console.WriteLine("Vendedor cadastrado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível cadastrar o vendedor. Limite atingido.");
                        }
                        break;

                    case 2:
                        Console.Write("Informe o ID do vendedor: ");
                        int consultaId = int.Parse(Console.ReadLine());
                        Vendedor vendedorConsultado = vendedores.SearchVendedor(consultaId);
                        if (vendedorConsultado != null)
                        {
                            Console.WriteLine($"ID: {vendedorConsultado.Id}, Nome: {vendedorConsultado.Nome}");
                            Console.WriteLine($"Total de Vendas: {vendedorConsultado.ValorVendas():C}");
                            Console.WriteLine($"Comissão: {vendedorConsultado.ValorComissao():C}");
                            Console.WriteLine($"Média de Vendas Diárias: {vendedorConsultado.ValorMedioDiario():C}");
                        }
                        else
                        {
                            Console.WriteLine("Vendedor não encontrado.");
                        }
                        break;

                    case 3:
                        Console.Write("Informe o ID do vendedor: ");
                        int excluiId = int.Parse(Console.ReadLine());
                        Vendedor vendedorExcluir = vendedores.SearchVendedor(excluiId);
                        if (vendedorExcluir != null && vendedores.DelVendedor(vendedorExcluir))
                        {
                            Console.WriteLine("Vendedor excluído com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível excluir o vendedor.");
                        }
                        break;

                    case 4:
                        Console.Write("Informe o ID do vendedor: ");
                        int vendaId = int.Parse(Console.ReadLine());
                        Vendedor vendedorVenda = vendedores.SearchVendedor(vendaId);
                        if (vendedorVenda != null)
                        {
                            Console.Write("Informe o dia da venda (1-31): ");
                            int dia = int.Parse(Console.ReadLine());
                            Console.Write("Informe a quantidade vendida: ");
                            int qtde = int.Parse(Console.ReadLine());
                            Console.Write("Informe o valor total da venda: ");
                            double valor = double.Parse(Console.ReadLine());
                            Venda venda = new Venda(qtde, valor);
                            vendedorVenda.RegistrarVenda(dia, venda);
                            Console.WriteLine("Venda registrada com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Vendedor não encontrado.");
                        }
                        break;

                    case 5:
                        vendedores.ListarVendedores();
                        break;
                }
            } while (opcao != 0);
        }
    }
}
