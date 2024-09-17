using DivisoresPrimosApi;
using Polly;

public class DivisorService : IDivisorService
{
    public virtual List<int> CalcularDivisores(int numero) // Torna o método "virtual"
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

    public bool IsPrimo(int numero)
    {
        if (numero < 2) return false;
        for (int i = 2; i <= Math.Sqrt(numero); i++)
        {
            if (numero % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    public async Task<List<int>> CalcularDivisoresComResiliencia(int numero)
    {
        var retryPolicy = Policy
            .Handle<Exception>()
            .RetryAsync(3, onRetry: (exception, retryCount) =>
            {
                Console.WriteLine($"Tentativa {retryCount} falhou. Motivo: {exception.Message}");
            });

        return await retryPolicy.ExecuteAsync(async () =>
        {
            return await Task.Run(() => CalcularDivisores(numero));
        });
    }
}
