using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CalculoLucro.Entidades
{
    public class CalculoLucroProduto
    {
        public void CapturaValores()
        {
            Console.WriteLine("=================================\n");
            Console.WriteLine("========= CALCULO LUCRO =========\n");
            Console.WriteLine("=================================\n");
            Console.Write("\nQuantidade de produtos vendidas?: ");
            var quantVendas = Convert.ToInt32(Console.ReadLine());

            var valorValidado = ValidarOsValores(quantVendas);

            if (valorValidado == true)
            {
                TratarDados(quantVendas);
            }
            Console.WriteLine("Houve um erro com os valores informado!");            

        }

        private bool ValidarOsValores(int quantVendas)
        {
            if (quantVendas <= 0)
            {
                Console.WriteLine("\nO valor não pode ser igual ou menor a 0!");
                return false;
            }
            return true;

        }

        public void TratarDados(int quantLinhas)
        {
            double[,] Produto = new double[quantLinhas, 3];
            var quantInformada = 0;
            var valorOriginal = 0.0; 
            var valorVenda = 0.0 ;
            var soma = 0.0;
            var lucro = 0.0;

            for (int lin = 0; lin < quantLinhas; lin++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Clear();
                    Console.Write($"\nQuantas vendas foram realizadas do produto {lin + 1}?: ");
                    quantInformada = Convert.ToInt32(Console.ReadLine());
                    col++;
                    Console.Write($"\nQual valor original do produto {lin + 1}?: ");
                    valorOriginal = Convert.ToDouble(Console.ReadLine());
                    soma = soma + (valorOriginal * quantInformada);
                    col++;
                    Console.Write($"\nQual o valor de venda do produto {lin + 1}?: ");
                    valorVenda = Convert.ToDouble(Console.ReadLine());
                    lucro = lucro + (valorVenda * quantInformada);
                    col++;
                    
                }
            }

            double imposto = lucro * 0.12;
            double total = lucro - soma - imposto;

            MostraValores(lucro, soma, imposto, total);

            
        }

        public void MostraValores(double lucro, double soma, double imposto, double total)
        {
            Console.Clear() ;
            Console.WriteLine("=================================\n");
            Console.WriteLine("========= CALCULO LUCRO =========\n");
            Console.WriteLine("=================================\n");
            Console.WriteLine($"O valor total de venda foi: {lucro}. \nO valor dos impostos recolhidos foi: {imposto}. \nO valor total original do produto é: {soma}. \nO lucro foi de: {total}");
        }
    }
}
