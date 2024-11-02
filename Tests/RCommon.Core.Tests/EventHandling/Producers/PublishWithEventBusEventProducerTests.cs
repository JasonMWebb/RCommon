using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RCommon.EventHandling;
using RCommon.EventHandling.Producers;
using System;
using System.Threading.Tasks;

namespace RCommon.Core.Tests.EventHandling.Producers
{
    [TestFixture]
    public class PublishWithEventBusEventProducerTests
    {
        private MockRepository mockRepository;

        private Mock<IEventBus> mockEventBus;
        private Mock<ILogger<PublishWithEventBusEventProducer>> mockLogger;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockEventBus = this.mockRepository.Create<IEventBus>();
            this.mockLogger = this.mockRepository.Create<ILogger<PublishWithEventBusEventProducer>>();
        }

        private PublishWithEventBusEventProducer CreatePublishWithEventBusEventProducer()
        {
            return new PublishWithEventBusEventProducer(
                this.mockEventBus.Object,
                this.mockLogger.Object);
        }

        [Test]
        public async Task ProduceEventAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var publishWithEventBusEventProducer = this.CreatePublishWithEventBusEventProducer();
            T @event = default(T);
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            await publishWithEventBusEventProducer.ProduceEventAsync(
                @event,
                cancellationToken);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
