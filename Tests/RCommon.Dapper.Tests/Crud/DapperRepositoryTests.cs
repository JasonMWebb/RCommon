using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RCommon;
using RCommon.Entities;
using RCommon.Persistence;
using RCommon.Persistence.Dapper.Crud;
using System;
using System.Threading.Tasks;

namespace RCommon.Dapper.Tests.Crud
{
    [TestFixture]
    public class DapperRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<IDataStoreFactory> mockDataStoreFactory;
        private Mock<ILoggerFactory> mockLoggerFactory;
        private Mock<IEntityEventTracker> mockEntityEventTracker;
        private Mock<IOptions<DefaultDataStoreOptions>> mockOptions;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDataStoreFactory = this.mockRepository.Create<IDataStoreFactory>();
            this.mockLoggerFactory = this.mockRepository.Create<ILoggerFactory>();
            this.mockEntityEventTracker = this.mockRepository.Create<IEntityEventTracker>();
            this.mockOptions = this.mockRepository.Create<IOptions<DefaultDataStoreOptions>>();
        }

        private DapperRepository CreateDapperRepository()
        {
            return new DapperRepository(
                this.mockDataStoreFactory.Object,
                this.mockLoggerFactory.Object,
                this.mockEntityEventTracker.Object,
                this.mockOptions.Object);
        }

        [Test]
        public async Task AddAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            TEntity entity = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            await dapperRepository.AddAsync(
                entity,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task DeleteAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            TEntity entity = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            await dapperRepository.DeleteAsync(
                entity,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task UpdateAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            TEntity entity = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            await dapperRepository.UpdateAsync(
                entity,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            ISpecification specification = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await dapperRepository.FindAsync(
                specification,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindAsync_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await dapperRepository.FindAsync(
                expression,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindAsync_StateUnderTest_ExpectedBehavior2()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            object primaryKey = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await dapperRepository.FindAsync(
                primaryKey,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetCountAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            ISpecification selectSpec = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await dapperRepository.GetCountAsync(
                selectSpec,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetCountAsync_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await dapperRepository.GetCountAsync(
                expression,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindSingleOrDefaultAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await dapperRepository.FindSingleOrDefaultAsync(
                expression,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindSingleOrDefaultAsync_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            ISpecification specification = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await dapperRepository.FindSingleOrDefaultAsync(
                specification,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task AnyAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await dapperRepository.AnyAsync(
                expression,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task AnyAsync_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var dapperRepository = this.CreateDapperRepository();
            ISpecification specification = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await dapperRepository.AnyAsync(
                specification,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
