using Moq;
using NUnit.Framework;
using RCommon.Reflection;
using System;

namespace RCommon.Core.Tests.Reflection
{
    [TestFixture]
    public class ObjectGraphWalkerTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ObjectGraphWalker CreateObjectGraphWalker()
        {
            return new ObjectGraphWalker();
        }

        [Test]
        public void TraverseGraphFor_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var objectGraphWalker = this.CreateObjectGraphWalker();
            object root = null;

            // Act
            var result = objectGraphWalker.TraverseGraphFor(
                root);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
