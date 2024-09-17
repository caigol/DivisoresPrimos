using System;
using System.Collections.Generic;
using System.Linq;

namespace DivisoresPrimos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite um número: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                var divisores = CalcularDivisores(numero);
                var divisoresPrimos = divisores.Where(IsPrimo).ToList();

                Console.WriteLine($"\nNúmero de Entrada: {numero}");
                Console.WriteLine("Números divisores: " + string.Join(" ", divisores));
                Console.WriteLine("Divisores Primos: " + string.Join(" ", divisoresPrimos));
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
            }
        }

        // Método para calcular todos os divisores de um número
        static List<int> CalcularDivisores(int numero)
        {
            var divisores = new List<int>();
            for (int i = 1; i <= numero; i++)
            {
                if (numero % i == 0)
                {
                    divisores.Add(i);
                }
            }
            return divisores;
        }

        // Método para verificar se um número é primo
        static bool IsPrimo(int numero)
        {
            if (numero < 2) return false; // 1 não é considerado primo
            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
