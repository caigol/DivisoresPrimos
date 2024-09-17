using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivisoresPrimosApi
{
    public interface IDivisorService
    {
        List<int> CalcularDivisores(int numero);
        Task<List<int>> CalcularDivisoresComResiliencia(int numero); // Método assíncrono
        bool IsPrimo(int numero);
    }
}
