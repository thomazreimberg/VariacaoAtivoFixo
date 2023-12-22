using Moq;
using Microsoft.Extensions.Logging;
using VariacaoAtivoFixo.Application.Interfaces;
using VariacaoAtivoFixo.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using VariacaoAtivoFixo.Application.Dto;

namespace VariacaoAtivoFixo.Test
{
    [TestFixture]
    public class AssetControllerTests
    {
        private Mock<ILogger<AssetController>> _mockLogger;
        private Mock<IAssetApplication> _mockAssetApplication;
        private AssetController _controller;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<AssetController>>();
            _mockAssetApplication = new Mock<IAssetApplication>();
            _controller = new AssetController(_mockLogger.Object, _mockAssetApplication.Object);
        }

        [Test]
        public void GetAssets_ReturnsListOfAssetDtoGet_WhenCalledWithValidPaper()
        {
            // Arrange
            var validPaper = "AAPL";
            var expectedAssets = new List<AssetDtoGet>(); // Populate with expected assets

            _mockAssetApplication.Setup(app => app.GetAssets(validPaper))
                                 .Returns(expectedAssets);

            // Act
            var result = _controller.GetAssets(validPaper);

            // Assert
            Assert.IsNotNull(result);
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(expectedAssets, okResult.Value);
        }
    }
}
