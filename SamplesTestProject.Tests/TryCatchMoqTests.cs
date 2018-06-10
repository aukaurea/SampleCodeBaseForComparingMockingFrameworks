using System;
using Microsoft.QualityTools.Testing.Fakes;
using NUnit.Framework;
using Moq;
using SampleTestsProejct;

namespace SamplesTestProject.Tests
{
    [TestFixture]
    public class TryCatchMoqTests
    {
        private readonly DateTime ConstDateTime = new DateTime(2009, 1, 20);
        private Mock<TryCatchThrowExample> _mockTryCatchThrowExample;
        private TryCatchThrowExample _tryCatchThrowExample;

        [SetUp]
        public void Init()
        {
            _tryCatchThrowExample = new TryCatchThrowExample();
            SetupMoq();
        }

        [TearDown]
        public void CleanUp()
        {
        }

        [Test]
        public void TryTest()
        {
            // Assert
            _mockTryCatchThrowExample.Verify(n => n.TryCatchWithThrowExample());
            _mockTryCatchThrowExample.Verify(n => n.TryCatchWithThrowExample(It.IsAny<string>(), It.IsAny<string>()));
        }

        private void SetupMoq()
        {
            _mockTryCatchThrowExample = new Mock<TryCatchThrowExample>();
            _mockTryCatchThrowExample.Setup(m => m.StringProperty1).Returns(string.Empty);
            _mockTryCatchThrowExample.Setup(m => m.TryCatchWithThrowExample()).Verifiable();
            _mockTryCatchThrowExample.SetupGet(n => n.StringProperty1).Returns(string.Empty);
            _mockTryCatchThrowExample.SetupSet(n => n.StringProperty1).Verifiable();
        }

    }
}
