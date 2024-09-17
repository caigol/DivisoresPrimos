using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DivisoresPrimosApi.Tests
{
    public class DivisorServiceTests
    {
        private readonly DivisorService _service;

        public DivisorServiceTests()
        {
            _service = new DivisorService();
        }

        [Fact]
        public void CalcularDivisores_DeveRetornarDivisoresCorretos()
        {
            // Arrange
            int numero = 45;

            // Act
            var resultado = _service.CalcularDivisores(numero);

            // Assert
            var divisoresEsperados = new List<int> { 1, 3, 5, 9, 15, 45 };
            Assert.Equal(divisoresEsperados, resultado);
        }

        [Fact]
        public void IsPrimo_DeveIdentificarNumerosPrimosCorretamente()
        {
            // Act & Assert
            Assert.False(_service.IsPrimo(1));
            Assert.True(_service.IsPrimo(3));
            Assert.False(_service.IsPrimo(4));
        }

        [Fact]
        public async Task CalcularDivisoresComResiliencia_DeveRetornarDivisoresCorretos()
        {
            // Arrange
            int numero = 45;

            // Act
            var resultado = await _service.CalcularDivisoresComResiliencia(numero);

            // Assert
            var divisoresEsperados = new List<int> { 1, 3, 5, 9, 15, 45 };
            Assert.Equal(divisoresEsperados, resultado);
        }

        [Fact]
        public async Task CalcularDivisoresComResiliencia_DeveTentarNovamenteEmCasoDeFalha()
        {
            // Arrange
            int numero = 45;
            var serviceWithException = new DivisorServiceWithError();

            var exception = await serviceWithException.CalcularDivisoresComResiliencia(numero);

            Assert.Equal(3, serviceWithException.AttemptCount); // Verifica se tentou 3 vezes
        }
    }

    // Classe simulada para forçar erro durante o cálculo
    public class DivisorServiceWithError : DivisorService
    {
        public int AttemptCount { get; private set; } = 0;

        public override List<int> CalcularDivisores(int numero)
        {
            AttemptCount++;
            if (AttemptCount < 3)
            {
                throw new Exception("Simulated failure");
            }

            return base.CalcularDivisores(numero); // Retorna o cálculo correto após 3 tentativas
        }
    }
}
