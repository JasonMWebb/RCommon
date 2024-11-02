using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework;
using RCommon.MemoryCache;
using System;
using System.Threading.Tasks;

namespace RCommon.MemoryCache.Tests
{
    [TestFixture]
    public class InMemoryCacheServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IMemoryCache> mockMemoryCache;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockMemoryCache = this.mockRepository.Create<IMemoryCache>();
        }

        private InMemoryCacheService CreateService()
        {
            return new InMemoryCacheService(
                this.mockMemoryCache.Object);
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
