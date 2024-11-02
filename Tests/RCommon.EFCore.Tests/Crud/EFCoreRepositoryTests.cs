using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RCommon;
using RCommon.Entities;
using RCommon.Persistence;
using RCommon.Persistence.EFCore.Crud;
using System;
using System.Threading.Tasks;

namespace RCommon.EFCore.Tests.Crud
{
    [TestFixture]
    public class EFCoreRepositoryTests
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

        private EFCoreRepository CreateEFCoreRepository()
        {
            return new EFCoreRepository(
                this.mockDataStoreFactory.Object,
                this.mockLoggerFactory.Object,
                this.mockEntityEventTracker.Object,
                this.mockOptions.Object);
        }

        [Test]
        public void Include_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            Expression path = null;

            // Act
            var result = eFCoreRepository.Include(
                path);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void ThenInclude_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            Expression path = null;

            // Act
            var result = eFCoreRepository.ThenInclude(
                path);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task AddAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            TEntity entity = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            await eFCoreRepository.AddAsync(
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
            var eFCoreRepository = this.CreateEFCoreRepository();
            TEntity entity = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            await eFCoreRepository.DeleteAsync(
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
            var eFCoreRepository = this.CreateEFCoreRepository();
            TEntity entity = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            await eFCoreRepository.UpdateAsync(
                entity,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetCountAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            ISpecification selectSpec = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await eFCoreRepository.GetCountAsync(
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
            var eFCoreRepository = this.CreateEFCoreRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await eFCoreRepository.GetCountAsync(
                expression,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void FindQuery_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            ISpecification specification = null;

            // Act
            var result = eFCoreRepository.FindQuery(
                specification);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void FindQuery_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            Expression expression = null;

            // Act
            var result = eFCoreRepository.FindQuery(
                expression);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            object primaryKey = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await eFCoreRepository.FindAsync(
                primaryKey,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindAsync_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            ISpecification specification = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await eFCoreRepository.FindAsync(
                specification,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindAsync_StateUnderTest_ExpectedBehavior2()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await eFCoreRepository.FindAsync(
                expression,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindAsync_StateUnderTest_ExpectedBehavior3()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            IPagedSpecification specification = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await eFCoreRepository.FindAsync(
                specification,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindAsync_StateUnderTest_ExpectedBehavior4()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            Expression expression = null;
            Expression orderByExpression = null;
            bool orderByAscending = false;
            int pageNumber = 0;
            int pageSize = 0;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await eFCoreRepository.FindAsync(
                expression,
                orderByExpression,
                orderByAscending,
                pageNumber,
                pageSize,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void FindQuery_StateUnderTest_ExpectedBehavior2()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            Expression expression = null;
            Expression orderByExpression = null;
            bool orderByAscending = false;
            int pageNumber = 0;
            int pageSize = 0;

            // Act
            var result = eFCoreRepository.FindQuery(
                expression,
                orderByExpression,
                orderByAscending,
                pageNumber,
                pageSize);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void FindQuery_StateUnderTest_ExpectedBehavior3()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            IPagedSpecification specification = null;

            // Act
            var result = eFCoreRepository.FindQuery(
                specification);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindSingleOrDefaultAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eFCoreRepository = this.CreateEFCoreRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await eFCoreRepository.FindSingleOrDefaultAsync(
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
            var eFCoreRepository = this.CreateEFCoreRepository();
            ISpecification specification = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await eFCoreRepository.FindSingleOrDefaultAsync(
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
            var eFCoreRepository = this.CreateEFCoreRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await eFCoreRepository.AnyAsync(
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
            var eFCoreRepository = this.CreateEFCoreRepository();
            ISpecification specification = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await eFCoreRepository.AnyAsync(
                specification,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
