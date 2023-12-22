using Moq;
using VariacaoAtivoFixo.Services.YahooFinance;
using VariacaoAtivoFixo.Services.YahooFinance.Contract;

namespace VariacaoAtivoFixo.Test
{
    [TestFixture]
    public class YahooFinanceServiceTest
    {
        private Mock<IRestClientWrapper> _mockWrapper;
        private const string BaseUrl = "https://query2.finance.yahoo.com/v8/finance/chart/";

        [SetUp]
        public void Setup()
        {
            _mockWrapper = new Mock<IRestClientWrapper>();
        }

        [Test]
        public async Task GetYahooFinance_ReturnsData()
        {
            // Arrange
            string paper = "AAPL";
            var expectedData = new YahooFinanceData();
            _mockWrapper.Setup(w => w.GetAsync<YahooFinanceData>(It.IsAny<string>()))
                       .ReturnsAsync(expectedData);

            var service = new YahooFinanceService(_mockWrapper.Object, BaseUrl);

            // Act
            var result = await service.GetYahooFinance(paper);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedData, result);
        }

        [Test]
        public void GetYahooFinance_ThrowsException_WhenApiFails()
        {
            // Arrange
            string paper = "UNKNOWN";

            _mockWrapper.Setup(w => w.GetAsync<YahooFinanceData>(It.IsAny<string>()))
                       .ReturnsAsync((YahooFinanceData)null); // Simulate a failed API call

            var service = new YahooFinanceService(_mockWrapper.Object);

            // Act & Assert
            // The service is expected to throw an exception due to the failed API call
            var exception = Assert.ThrowsAsync<Exception>(async () => await service.GetYahooFinance(paper));
            Assert.That(exception.Message, Is.EqualTo("Error in call."));
        }
    }
}
