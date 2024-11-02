using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RCommon.EventHandling.Producers;
using System;
using System.Threading.Tasks;

namespace RCommon.Core.Tests.EventHandling.Producers
{
    [TestFixture]
    public class InMemoryTransactionalEventRouterTests
    {
        private MockRepository mockRepository;

        private Mock<IServiceProvider> mockServiceProvider;
        private Mock<ILogger<InMemoryTransactionalEventRouter>> mockLogger;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockServiceProvider = this.mockRepository.Create<IServiceProvider>();
            this.mockLogger = this.mockRepository.Create<ILogger<InMemoryTransactionalEventRouter>>();
        }

        private InMemoryTransactionalEventRouter CreateInMemoryTransactionalEventRouter()
        {
            return new InMemoryTransactionalEventRouter(
                this.mockServiceProvider.Object,
                this.mockLogger.Object);
        }

        [Test]
        public async Task RouteEventsAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var inMemoryTransactionalEventRouter = this.CreateInMemoryTransactionalEventRouter();
            IEnumerable transactionalEvents = null;

            // Act
            await inMemoryTransactionalEventRouter.RouteEventsAsync(
                transactionalEvents);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task RouteEventsAsync_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var inMemoryTransactionalEventRouter = this.CreateInMemoryTransactionalEventRouter();

            // Act
            await inMemoryTransactionalEventRouter.RouteEventsAsync();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void AddTransactionalEvent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var inMemoryTransactionalEventRouter = this.CreateInMemoryTransactionalEventRouter();
            ISerializableEvent serializableEvent = null;

            // Act
            inMemoryTransactionalEventRouter.AddTransactionalEvent(
                serializableEvent);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void AddTransactionalEvents_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var inMemoryTransactionalEventRouter = this.CreateInMemoryTransactionalEventRouter();
            IEnumerable serializableEvents = null;

            // Act
            inMemoryTransactionalEventRouter.AddTransactionalEvents(
                serializableEvents);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
