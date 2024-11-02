using Moq;
using NUnit.Framework;
using RCommon;
using RCommon.Persistence.Transactions;
using System;

namespace RCommon.Persistence.Tests.Transactions
{
    [TestFixture]
    public class UnitOfWorkFactoryTests
    {
        private MockRepository mockRepository;

        private Mock<IServiceProvider> mockServiceProvider;
        private Mock<IGuidGenerator> mockGuidGenerator;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockServiceProvider = this.mockRepository.Create<IServiceProvider>();
            this.mockGuidGenerator = this.mockRepository.Create<IGuidGenerator>();
        }

        private UnitOfWorkFactory CreateFactory()
        {
            return new UnitOfWorkFactory(
                this.mockServiceProvider.Object,
                this.mockGuidGenerator.Object);
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = this.CreateFactory();

            // Act
            var result = factory.Create();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var factory = this.CreateFactory();
            TransactionMode transactionMode = default(global::RCommon.Persistence.Transactions.TransactionMode);

            // Act
            var result = factory.Create(
                transactionMode);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior2()
        {
            // Arrange
            var factory = this.CreateFactory();
            TransactionMode transactionMode = default(global::RCommon.Persistence.Transactions.TransactionMode);
            IsolationLevel isolationLevel = default(global::System.Transactions.IsolationLevel);

            // Act
            var result = factory.Create(
                transactionMode,
                isolationLevel);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
