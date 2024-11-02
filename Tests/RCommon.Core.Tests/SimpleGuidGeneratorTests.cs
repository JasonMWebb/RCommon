using Moq;
using NUnit.Framework;
using RCommon;

namespace RCommon.Core.Tests
{
    [TestFixture]
    public class SimpleGuidGeneratorTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private SimpleGuidGenerator CreateSimpleGuidGenerator()
        {
            return new SimpleGuidGenerator();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var simpleGuidGenerator = this.CreateSimpleGuidGenerator();

            // Act
            var result = simpleGuidGenerator.Create();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
