using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RCommon;
using RCommon.ApplicationServices;
using RCommon.ApplicationServices.Commands;
using RCommon.ApplicationServices.Validation;
using RCommon.Caching;
using System;
using System.Threading.Tasks;

namespace RCommon.ApplicationServices.Tests.Commands
{
    [TestFixture]
    public class CommandBusTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<CommandBus>> mockLogger;
        private Mock<IServiceProvider> mockServiceProvider;
        private Mock<IValidationService> mockValidationService;
        private Mock<IOptions<CqrsValidationOptions>> mockOptionsCqrsValidationOptions;
        private Mock<IOptions<CachingOptions>> mockOptionsCachingOptions;
        private Mock<ICommonFactory<ExpressionCachingStrategy, ICacheService>> mockCommonFactory;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLogger = this.mockRepository.Create<ILogger<CommandBus>>();
            this.mockServiceProvider = this.mockRepository.Create<IServiceProvider>();
            this.mockValidationService = this.mockRepository.Create<IValidationService>();
            this.mockOptionsCqrsValidationOptions = this.mockRepository.Create<IOptions<CqrsValidationOptions>>();
            this.mockOptionsCachingOptions = this.mockRepository.Create<IOptions<CachingOptions>>();
            this.mockCommonFactory = this.mockRepository.Create<ICommonFactory<ExpressionCachingStrategy, ICacheService>>();
        }

        private CommandBus CreateCommandBus()
        {
            return new CommandBus(
                this.mockLogger.Object,
                this.mockServiceProvider.Object,
                this.mockValidationService.Object,
                this.mockOptionsCqrsValidationOptions.Object,
                this.mockOptionsCachingOptions.Object,
                this.mockCommonFactory.Object);
        }

        [Test]
        public async Task DispatchCommandAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var commandBus = this.CreateCommandBus();
            ICommand command = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await commandBus.DispatchCommandAsync(
                command,
                cancellationToken);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
