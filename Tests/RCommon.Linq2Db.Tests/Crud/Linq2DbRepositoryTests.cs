using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RCommon;
using RCommon.Entities;
using RCommon.Persistence;
using RCommon.Persistence.Linq2Db.Crud;
using System;
using System.Threading.Tasks;

namespace RCommon.Linq2Db.Tests.Crud
{
    [TestFixture]
    public class Linq2DbRepositoryTests
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

        private Linq2DbRepository CreateLinq2DbRepository()
        {
            return new Linq2DbRepository(
                this.mockDataStoreFactory.Object,
                this.mockLoggerFactory.Object,
                this.mockEntityEventTracker.Object,
                this.mockOptions.Object);
        }

        [Test]
        public void Include_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var linq2DbRepository = this.CreateLinq2DbRepository();
            Expression path = null;

            // Act
            var result = linq2DbRepository.Include(
                path);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void ThenInclude_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var linq2DbRepository = this.CreateLinq2DbRepository();
            Expression path = null;

            // Act
            var result = linq2DbRepository.ThenInclude(
                path);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task AddAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var linq2DbRepository = this.CreateLinq2DbRepository();
            TEntity entity = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            await linq2DbRepository.AddAsync(
                entity,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task AnyAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var linq2DbRepository = this.CreateLinq2DbRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await linq2DbRepository.AnyAsync(
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
            var linq2DbRepository = this.CreateLinq2DbRepository();
            ISpecification specification = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await linq2DbRepository.AnyAsync(
                specification,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task DeleteAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var linq2DbRepository = this.CreateLinq2DbRepository();
            TEntity entity = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            await linq2DbRepository.DeleteAsync(
                entity,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void FindQuery_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var linq2DbRepository = this.CreateLinq2DbRepository();
            ISpecification specification = null;

            // Act
            var result = linq2DbRepository.FindQuery(
                specification);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void FindQuery_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var linq2DbRepository = this.CreateLinq2DbRepository();
            Expression expression = null;

            // Act
            var result = linq2DbRepository.FindQuery(
                expression);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var linq2DbRepository = this.CreateLinq2DbRepository();
            object primaryKey = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await linq2DbRepository.FindAsync(
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
            var linq2DbRepository = this.CreateLinq2DbRepository();
            ISpecification specification = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await linq2DbRepository.FindAsync(
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
            var linq2DbRepository = this.CreateLinq2DbRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await linq2DbRepository.FindAsync(
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
            var linq2DbRepository = this.CreateLinq2DbRepository();
            IPagedSpecification specification = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await linq2DbRepository.FindAsync(
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
            var linq2DbRepository = this.CreateLinq2DbRepository();
            Expression expression = null;
            Expression orderByExpression = null;
            bool orderByAscending = false;
            int pageNumber = 0;
            int pageSize = 0;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await linq2DbRepository.FindAsync(
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
            var linq2DbRepository = this.CreateLinq2DbRepository();
            Expression expression = null;
            Expression orderByExpression = null;
            bool orderByAscending = false;
            int pageNumber = 0;
            int pageSize = 0;

            // Act
            var result = linq2DbRepository.FindQuery(
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
            var linq2DbRepository = this.CreateLinq2DbRepository();
            IPagedSpecification specification = null;

            // Act
            var result = linq2DbRepository.FindQuery(
                specification);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task FindSingleOrDefaultAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var linq2DbRepository = this.CreateLinq2DbRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await linq2DbRepository.FindSingleOrDefaultAsync(
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
            var linq2DbRepository = this.CreateLinq2DbRepository();
            ISpecification specification = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await linq2DbRepository.FindSingleOrDefaultAsync(
                specification,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetCountAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var linq2DbRepository = this.CreateLinq2DbRepository();
            ISpecification selectSpec = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await linq2DbRepository.GetCountAsync(
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
            var linq2DbRepository = this.CreateLinq2DbRepository();
            Expression expression = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            var result = await linq2DbRepository.GetCountAsync(
                expression,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task UpdateAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var linq2DbRepository = this.CreateLinq2DbRepository();
            TEntity entity = null;
            CancellationToken token = default(global::System.Threading.CancellationToken);

            // Act
            await linq2DbRepository.UpdateAsync(
                entity,
                token);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
