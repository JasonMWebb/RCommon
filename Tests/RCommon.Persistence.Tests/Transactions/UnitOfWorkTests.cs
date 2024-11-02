using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RCommon;
using RCommon.Persistence.Transactions;

namespace RCommon.Persistence.Tests.Transactions
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<UnitOfWork>> mockLogger;
        private Mock<IGuidGenerator> mockGuidGenerator;
        private Mock<IOptions<UnitOfWorkSettings>> mockOptions;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLogger = this.mockRepository.Create<ILogger<UnitOfWork>>();
            this.mockGuidGenerator = this.mockRepository.Create<IGuidGenerator>();
            this.mockOptions = this.mockRepository.Create<IOptions<UnitOfWorkSettings>>();
        }

        private UnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(
                this.mockLogger.Object,
                this.mockGuidGenerator.Object,
                this.mockOptions.Object);
        }

        [Test]
        public void Commit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitOfWork = this.CreateUnitOfWork();

            // Act
            unitOfWork.Commit();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
