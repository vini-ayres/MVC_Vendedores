using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Vendedores
{
    class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas;
        private int totalVendasRegistradas = 0;

        public Vendedor(int id, string nome, double percComissao)
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
            asVendas = new Venda[31]; // Vendas de um mês
        }

        public void RegistrarVenda(int dia, Venda venda)
        {
            if (dia >= 1 && dia <= 31)
            {
                asVendas[dia - 1] = venda;
                totalVendasRegistradas++;
            }
        }

        public double ValorVendas()
        {
            double total = 0;
            for (int i = 0; i < 31; i++)
            {
                if (asVendas[i] != null)
                {
                    total += asVendas[i].ValorTotal();
                }
            }
            return total;
        }

        public double ValorComissao()
        {
            return ValorVendas() * percComissao / 100;
        }

        public double ValorMedioDiario()
        {
            double total = 0;
            int diasComVenda = 0;
            for (int i = 0; i < 31; i++)
            {
                if (asVendas[i] != null)
                {
                    total += asVendas[i].ValorMedio();
                    diasComVenda++;
                }
            }
            return diasComVenda > 0 ? total / diasComVenda : 0;
        }

        public int Id => id;
        public string Nome => nome;
        public int TotalVendasRegistradas => totalVendasRegistradas;
    }

}
