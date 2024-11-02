using LinqToDB;
using Moq;
using NUnit.Framework;
using RCommon.Persistence.Linq2Db;

namespace RCommon.Linq2Db.Tests
{
    [TestFixture]
    public class RCommonDataConnectionTests
    {
        private MockRepository mockRepository;

        private Mock<DataOptions> mockDataOptions;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDataOptions = this.mockRepository.Create<DataOptions>();
        }

        private RCommonDataConnection CreateRCommonDataConnection()
        {
            return new RCommonDataConnection(
                this.mockDataOptions.Object);
        }

        [Test]
        public void GetDbConnection_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var rCommonDataConnection = this.CreateRCommonDataConnection();

            // Act
            var result = rCommonDataConnection.GetDbConnection();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
