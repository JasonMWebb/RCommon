using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RCommon;
using RCommon.ApplicationServices;
using RCommon.ApplicationServices.Queries;
using RCommon.ApplicationServices.Validation;
using RCommon.Caching;
using System;
using System.Threading.Tasks;

namespace RCommon.ApplicationServices.Tests.Queries
{
    [TestFixture]
    public class QueryBusTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<QueryBus>> mockLogger;
        private Mock<IServiceProvider> mockServiceProvider;
        private Mock<IValidationService> mockValidationService;
        private Mock<IOptions<CqrsValidationOptions>> mockOptionsCqrsValidationOptions;
        private Mock<IOptions<CachingOptions>> mockOptionsCachingOptions;
        private Mock<ICommonFactory<ExpressionCachingStrategy, ICacheService>> mockCommonFactory;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLogger = this.mockRepository.Create<ILogger<QueryBus>>();
            this.mockServiceProvider = this.mockRepository.Create<IServiceProvider>();
            this.mockValidationService = this.mockRepository.Create<IValidationService>();
            this.mockOptionsCqrsValidationOptions = this.mockRepository.Create<IOptions<CqrsValidationOptions>>();
            this.mockOptionsCachingOptions = this.mockRepository.Create<IOptions<CachingOptions>>();
            this.mockCommonFactory = this.mockRepository.Create<ICommonFactory<ExpressionCachingStrategy, ICacheService>>();
        }

        private QueryBus CreateQueryBus()
        {
            return new QueryBus(
                this.mockLogger.Object,
                this.mockServiceProvider.Object,
                this.mockValidationService.Object,
                this.mockOptionsCqrsValidationOptions.Object,
                this.mockOptionsCachingOptions.Object,
                this.mockCommonFactory.Object);
        }

        [Test]
        public async Task DispatchQueryAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var queryBus = this.CreateQueryBus();
            IQuery query = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await queryBus.DispatchQueryAsync(
                query,
                cancellationToken);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
