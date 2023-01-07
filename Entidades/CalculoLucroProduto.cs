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
            //Captura dos valores
            Console.WriteLine("=================================\n");
            Console.WriteLine("========= CALCULO LUCRO =========\n");
            Console.WriteLine("=================================\n");
            Console.Write("\nQuantidade de produtos vendidas?: ");
            var quantVendas = Convert.ToInt32(Console.ReadLine());

            // enviando para funcao private para validação do valor, recebendo um booleano
            var valorValidado = ValidarOsValores(quantVendas);

            // validando se o booleano foi verdadeiro
            if (valorValidado == false)
            {
                //Caso falso recebe erro e finaliza o programa
                Console.WriteLine("\nHouve um erro com o valor de venda informado!");   
            }
            // caso booleano seja verdade o valor é enviado para a função de tabela
            Tabela(quantVendas);
        }

        // função privada para validar o valor de vendas que foi inserido pelo usuario
        private bool ValidarOsValores(int quantVendas)
        {
            // condição para verificar se o valor é valido
            if (quantVendas <= 0)
            {
                // se falso, retorna uma mensagem 
                Console.WriteLine("\nO valor não pode ser igual ou menor a 0!");
                return false;
            }
            // caso verdade retorna true
            return true;

        }

        // função par criar Matriz e calcular os valores
        public void Tabela(int quantLinhas)
        {
            // criação da Matriz e as variáveis utilizadas
            double[,] Produto = new double[quantLinhas, 3];
            var quantInformada = 0;
            var valorOriginal = 0.0; 
            var valorVenda = 0.0 ;
            var soma = 0.0;
            var lucro = 0.0;

            // abertura do FOR para percorrer a linha, linha essas igual a quantidade total de vendas
            for (int lin = 0; lin < quantLinhas; lin++)
            {
                // abertura do FOR para percorrer coluna, não necessário, mas caso no futuro o cliente queira adicionar quantidade de coluna a ser preenchida, pode receber dinamicamente
                for (int col = 0; col < 3; col++)
                {
                    // captura dos valores, guardando na variável e enviando para Matriz, após damos um salto de coluna, para preencher a proxima
                    Console.Clear();
                    Console.Write($"\nQuantas vendas foram realizadas do produto {lin + 1}?: ");
                    quantInformada = Convert.ToInt32(Console.ReadLine());
                    Produto[lin, col] = quantInformada;
                    col++;
                    Console.Write($"\nQual valor original do produto {lin + 1}?: ");
                    valorOriginal = Convert.ToDouble(Console.ReadLine());
                    soma = soma + (valorOriginal * quantInformada);
                    Produto[lin, col] = valorOriginal;
                    col++;
                    Console.Write($"\nQual o valor de venda do produto {lin + 1}?: ");
                    valorVenda = Convert.ToDouble(Console.ReadLine());
                    lucro = lucro + (valorVenda * quantInformada);
                    Produto[lin, col] = valorVenda;
                    col++;
                    
                }
            }

            // calculo dos impostos, lucro e valor total com a dedução do imposto
            double imposto = lucro * 0.12;
            double total = lucro - soma - imposto;

            // enviando valores trabalhados para a visualização
            MostraValores(lucro, soma, imposto, total);

                    
        }

        public void MostraValores(double lucro, double soma, double imposto, double total)
        {
            // exibição dos valores finais
            Console.Clear();
            Console.WriteLine("=================================\n");
            Console.WriteLine("========= CALCULO LUCRO =========\n");
            Console.WriteLine("=================================\n");
            Console.WriteLine($"O valor total de venda foi: {lucro.ToString("C2")}. \nO valor dos impostos recolhidos foi: {imposto.ToString("C2")}. \nO valor total original do produto é: {soma.ToString("C2")}. \nO lucro foi de: {total.ToString("C2")}");
        }
    }
}
