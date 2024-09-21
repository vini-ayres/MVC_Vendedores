using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Vendedores
{
    class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public Vendedores(int max)
        {
            this.max = max;
            this.qtde = 0;
            osVendedores = new Vendedor[max];
        }

        public bool AddVendedor(Vendedor v)
        {
            if (qtde < max)
            {
                osVendedores[qtde++] = v;
                return true;
            }
            return false;
        }

        public bool DelVendedor(Vendedor v)
        {
            if (v.TotalVendasRegistradas == 0)
            {
                for (int i = 0; i < qtde; i++)
                {
                    if (osVendedores[i] == v)
                    {
                        for (int j = i; j < qtde - 1; j++)
                        {
                            osVendedores[j] = osVendedores[j + 1];
                        }
                        osVendedores[--qtde] = null;
                        return true;
                    }
                }
            }
            return false;
        }

        public Vendedor SearchVendedor(int id)
        {
            foreach (var v in osVendedores)
            {
                if (v != null && v.Id == id)
                    return v;
            }
            return null;
        }

        public double ValorVendas()
        {
            double total = 0;
            foreach (var v in osVendedores)
            {
                if (v != null)
                    total += v.ValorVendas();
            }
            return total;
        }

        public double ValorComissao()
        {
            double total = 0;
            foreach (var v in osVendedores)
            {
                if (v != null)
                    total += v.ValorComissao();
            }
            return total;
        }

        public void ListarVendedores()
        {
            double totalVendas = 0;
            double totalComissao = 0;

            foreach (var v in osVendedores)
            {
                if (v != null)
                {
                    Console.WriteLine($"ID: {v.Id}, Nome: {v.Nome}, Total Vendas: {v.ValorVendas():C}, Comissão: {v.ValorComissao():C}");
                    totalVendas += v.ValorVendas();
                    totalComissao += v.ValorComissao();
                }
            }
            Console.WriteLine($"Total Geral de Vendas: {totalVendas:C}");
            Console.WriteLine($"Total Geral de Comissões: {totalComissao:C}");
        }
    }
}
