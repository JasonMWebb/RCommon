using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RCommon.Persistence;
using System;

namespace RCommon.Persistence.Tests
{
    [TestFixture]
    public class DataStoreFactoryTests
    {
        private MockRepository mockRepository;

        private Mock<IServiceProvider> mockServiceProvider;
        private Mock<IOptions<DataStoreFactoryOptions>> mockOptions;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockServiceProvider = this.mockRepository.Create<IServiceProvider>();
            this.mockOptions = this.mockRepository.Create<IOptions<DataStoreFactoryOptions>>();
        }

        private DataStoreFactory CreateFactory()
        {
            return new DataStoreFactory(
                this.mockServiceProvider.Object,
                this.mockOptions.Object);
        }

        [Test]
        public void Resolve_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = this.CreateFactory();
            string name = null;

            // Act
            var result = factory.Resolve(
                name);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Resolve_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var factory = this.CreateFactory();
            string name = null;

            // Act
            var result = factory.Resolve(
                name);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
