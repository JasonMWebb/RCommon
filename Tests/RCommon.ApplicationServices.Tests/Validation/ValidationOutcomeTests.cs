using Moq;
using NUnit.Framework;
using RCommon.ApplicationServices.Validation;
using System;

namespace RCommon.ApplicationServices.Tests.Validation
{
    [TestFixture]
    public class ValidationOutcomeTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ValidationOutcome CreateValidationOutcome()
        {
            return new ValidationOutcome();
        }

        [Test]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var validationOutcome = this.CreateValidationOutcome();

            // Act
            var result = validationOutcome.ToString();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void ToString_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var validationOutcome = this.CreateValidationOutcome();
            string separator = null;

            // Act
            var result = validationOutcome.ToString(
                separator);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void ToDictionary_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var validationOutcome = this.CreateValidationOutcome();

            // Act
            var result = validationOutcome.ToDictionary();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
