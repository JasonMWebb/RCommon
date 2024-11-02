using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RCommon;
using System;

namespace RCommon.Core.Tests
{
    [TestFixture]
    public class SystemTimeTests
    {
        private MockRepository mockRepository;

        private Mock<IOptions<SystemTimeOptions>> mockOptions;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockOptions = this.mockRepository.Create<IOptions<SystemTimeOptions>>();
        }

        private SystemTime CreateSystemTime()
        {
            return new SystemTime(
                this.mockOptions.Object);
        }

        [Test]
        public void Normalize_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var systemTime = this.CreateSystemTime();
            DateTime dateTime = default(global::System.DateTime);

            // Act
            var result = systemTime.Normalize(
                dateTime);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
