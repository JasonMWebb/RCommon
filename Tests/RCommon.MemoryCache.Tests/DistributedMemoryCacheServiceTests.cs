using Microsoft.Extensions.Caching.Distributed;
using Moq;
using NUnit.Framework;
using RCommon.Json;
using RCommon.MemoryCache;
using System;
using System.Threading.Tasks;

namespace RCommon.MemoryCache.Tests
{
    [TestFixture]
    public class DistributedMemoryCacheServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IDistributedCache> mockDistributedCache;
        private Mock<IJsonSerializer> mockJsonSerializer;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDistributedCache = this.mockRepository.Create<IDistributedCache>();
            this.mockJsonSerializer = this.mockRepository.Create<IJsonSerializer>();
        }

        private DistributedMemoryCacheService CreateService()
        {
            return new DistributedMemoryCacheService(
                this.mockDistributedCache.Object,
                this.mockJsonSerializer.Object);
        }

        [Test]
        public void GetOrCreate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            object key = null;
            Func data = null;

            // Act
            var result = service.GetOrCreate(
                key,
                data);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetOrCreateAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            object key = null;
            Func data = null;

            // Act
            var result = await service.GetOrCreateAsync(
                key,
                data);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
