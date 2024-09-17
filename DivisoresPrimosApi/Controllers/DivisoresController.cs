using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DivisoresPrimosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisoresController : ControllerBase
    {
        private readonly IDivisorService _divisorService;

        public DivisoresController(IDivisorService divisorService)
        {
            _divisorService = divisorService;
        }

        [HttpGet("{numero}")]
        public async Task<IActionResult> GetDivisoresAsync(int numero)
        {
            if (numero <= 0)
            {
                return BadRequest("O número deve ser maior que zero.");
            }

            // Usa o método com resiliência
            var divisores = await _divisorService.CalcularDivisoresComResiliencia(numero);
            var divisoresPrimos = divisores.Where(_divisorService.IsPrimo).ToList();

            return Ok(new DivisoresResponse
            {
                NumeroEntrada = numero,
                Divisores = divisores,
                DivisoresPrimos = divisoresPrimos
            });
        }
    }
}
