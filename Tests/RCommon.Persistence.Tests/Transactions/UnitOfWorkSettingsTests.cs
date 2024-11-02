using Moq;
using NUnit.Framework;
using RCommon.Persistence.Transactions;

namespace RCommon.Persistence.Tests.Transactions
{
    [TestFixture]
    public class UnitOfWorkSettingsTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private UnitOfWorkSettings CreateUnitOfWorkSettings()
        {
            return new UnitOfWorkSettings();
        }

        [Test]
        public void TestMethod1()
        {
            // Arrange
            var unitOfWorkSettings = this.CreateUnitOfWorkSettings();

            // Act


            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
