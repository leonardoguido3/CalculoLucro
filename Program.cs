using CalculoLucro.Entidades;

namespace CalculoLucro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // instanciando a classe e chamando a função para captura de valores
            CalculoLucroProduto calculo = new CalculoLucroProduto();
            calculo.CapturaValores();
        }
    }
}