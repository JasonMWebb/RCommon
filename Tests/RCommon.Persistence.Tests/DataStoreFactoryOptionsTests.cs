using Moq;
using NUnit.Framework;
using RCommon.Persistence;
using System;

namespace RCommon.Persistence.Tests
{
    [TestFixture]
    public class DataStoreFactoryOptionsTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private DataStoreFactoryOptions CreateDataStoreFactoryOptions()
        {
            return new DataStoreFactoryOptions();
        }

        [Test]
        public void Register_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dataStoreFactoryOptions = this.CreateDataStoreFactoryOptions();
            string name = null;

            // Act
            dataStoreFactoryOptions.Register(
                name);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
