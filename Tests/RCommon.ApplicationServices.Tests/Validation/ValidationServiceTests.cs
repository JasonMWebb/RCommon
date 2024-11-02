using Moq;
using NUnit.Framework;
using RCommon.ApplicationServices.Validation;
using System;
using System.Threading.Tasks;

namespace RCommon.ApplicationServices.Tests.Validation
{
    [TestFixture]
    public class ValidationServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IServiceProvider> mockServiceProvider;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockServiceProvider = this.mockRepository.Create<IServiceProvider>();
        }

        private ValidationService CreateService()
        {
            return new ValidationService(
                this.mockServiceProvider.Object);
        }

        [Test]
        public async Task ValidateAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            T target = null;
            bool throwOnFaults = false;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await service.ValidateAsync(
                target,
                throwOnFaults,
                cancellationToken);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
