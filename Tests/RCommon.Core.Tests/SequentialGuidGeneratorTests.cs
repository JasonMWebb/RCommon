using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RCommon;
using System;

namespace RCommon.Core.Tests
{
    [TestFixture]
    public class SequentialGuidGeneratorTests
    {
        private MockRepository mockRepository;

        private Mock<IOptions<SequentialGuidGeneratorOptions>> mockOptions;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockOptions = this.mockRepository.Create<IOptions<SequentialGuidGeneratorOptions>>();
        }

        private SequentialGuidGenerator CreateSequentialGuidGenerator()
        {
            return new SequentialGuidGenerator(
                this.mockOptions.Object);
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sequentialGuidGenerator = this.CreateSequentialGuidGenerator();

            // Act
            var result = sequentialGuidGenerator.Create();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var sequentialGuidGenerator = this.CreateSequentialGuidGenerator();
            SequentialGuidType guidType = default(global::RCommon.SequentialGuidType);

            // Act
            var result = sequentialGuidGenerator.Create(
                guidType);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
