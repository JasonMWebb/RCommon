using Moq;
using NUnit.Framework;
using RCommon.Caching;
using System;

namespace RCommon.Caching.Tests
{
    [TestFixture]
    public class CacheKeyTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private CacheKey CreateCacheKey()
        {
            return new CacheKey(
                TODO);
        }

        [Test]
        public void With_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cacheKey = this.CreateCacheKey();
            string[] keys = null;

            // Act
            var result = cacheKey.With(
                keys);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void With_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var cacheKey = this.CreateCacheKey();
            Type ownerType = null;
            string[] keys = null;

            // Act
            var result = cacheKey.With(
                ownerType,
                keys);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
