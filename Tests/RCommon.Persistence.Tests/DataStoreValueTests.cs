using Moq;
using NUnit.Framework;
using RCommon.Persistence;
using System;

namespace RCommon.Persistence.Tests
{
    [TestFixture]
    public class DataStoreValueTests
    {
        private MockRepository mockRepository;

        private Mock<Type> mockType;
        private Mock<Type> mockType;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockType = this.mockRepository.Create<Type>();
            this.mockType = this.mockRepository.Create<Type>();
        }

        private DataStoreValue CreateDataStoreValue()
        {
            return new DataStoreValue(
                TODO,
                this.mockType.Object,
                this.mockType.Object);
        }

        [Test]
        public void TestMethod1()
        {
            // Arrange
            var dataStoreValue = this.CreateDataStoreValue();

            // Act


            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
