using CalculoLucro.Entidades;

namespace CalculoLucro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculoLucroProduto calculo = new CalculoLucroProduto();
            calculo.CapturaValores();
        }
    }
}