using DivisoresPrimosApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DivisoresPrimosApi.Tests
{
    public class DivisoresControllerTests
    {
        private readonly Mock<IDivisorService> _mockService;
        private readonly DivisoresController _controller;

        public DivisoresControllerTests()
        {
            _mockService = new Mock<IDivisorService>();
            _controller = new DivisoresController(_mockService.Object);
        }

        [Fact]
        public async Task GetDivisoresAsync_DeveRetornarDivisoresEPrimosCorretamente()
        {
            // Arrange
            int numero = 45;
            _mockService.Setup(s => s.CalcularDivisoresComResiliencia(numero))
                .ReturnsAsync(new List<int> { 1, 3, 5, 9, 15, 45 });
            _mockService.Setup(s => s.IsPrimo(It.IsAny<int>()))
                .Returns<int>(n => n == 1 || n == 3 || n == 5);

            // Act
            var resultado = await _controller.GetDivisoresAsync(numero) as OkObjectResult;

            // Assert
            Assert.NotNull(resultado);
            var response = resultado.Value as DivisoresResponse;
            Assert.Equal(numero, response.NumeroEntrada);
            Assert.Contains(3, response.DivisoresPrimos);
        }
    }
}
