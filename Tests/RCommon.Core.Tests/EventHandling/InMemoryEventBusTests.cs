using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using RCommon.EventHandling;
using System;
using System.Threading.Tasks;

namespace RCommon.Core.Tests.EventHandling
{
    [TestFixture]
    public class InMemoryEventBusTests
    {
        private MockRepository mockRepository;

        private Mock<IServiceProvider> mockServiceProvider;
        private Mock<IServiceCollection> mockServiceCollection;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockServiceProvider = this.mockRepository.Create<IServiceProvider>();
            this.mockServiceCollection = this.mockRepository.Create<IServiceCollection>();
        }

        private InMemoryEventBus CreateInMemoryEventBus()
        {
            return new InMemoryEventBus(
                this.mockServiceProvider.Object,
                this.mockServiceCollection.Object);
        }

        [Test]
        public void Subscribe_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var inMemoryEventBus = this.CreateInMemoryEventBus();

            // Act
            var result = inMemoryEventBus.Subscribe();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void SubscribeAllHandledEvents_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var inMemoryEventBus = this.CreateInMemoryEventBus();

            // Act
            var result = inMemoryEventBus.SubscribeAllHandledEvents();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task PublishAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var inMemoryEventBus = this.CreateInMemoryEventBus();
            TEvent @event = default(TEvent);

            // Act
            await inMemoryEventBus.PublishAsync(
                @event);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
