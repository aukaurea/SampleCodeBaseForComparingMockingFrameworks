using System;
using NUnit.Framework;
using Telerik.JustMock;

namespace SampleCodeBase.Tests
{
    [TestFixture]
    public class TryCatchJustMockTests
    {
        private TryCatchThrowExample _tryCatch;
        private readonly DateTime ConstDateTime = new DateTime(2009, 1, 20);
        private TryCatchThrowExample _mockTryCatch;
        private dynamic _wrapTryCatchNonPublic;

        [SetUp]
        public void Init()
        {
            _tryCatch = new TryCatchThrowExample();
        }

        [TearDown]
        public void CleanUp()
        {
        }

        [Test]
        public void TryCatchUsingMSFakesTest()
        {
            // Arrange
            SetupJustMock();

            // Act, Assert
            _tryCatch.TryCatchWithThrowExample();
        }

        [Test]
        public void TryCatchParametersUsingMSFakesTest()
        {
            // Arrange
            SetupJustMock();

            // Act, Assert
            _tryCatch.TryCatchWithThrowExample("", "");
        }

        [Test]
        public void CatchParametersUsingMSFakesTest()
        {
            // Arrange
            SetupJustMock();
            //ShimTryCatchThrowExample.PrivateStaticStringProperty1Get = () =>
            //{
            //    throw new ArgumentException();
            //    return string.Empty;
            //};

            // Act, Assert
            _tryCatch.TryCatchWithThrowExample("", "");
        }


        [Test]
        public void DatabaseCallPauseFor30SecondsAndThrowsReturnsTrueTests()
        {
            // Arrange
            SetupJustMock();
            Mock.NonPublic.Arrange<string>(_wrapTryCatchNonPublic.PrivateStaticStringProperty1).Returns(string.Empty);


            // Act, Assert
            //PrivateMethod()
            var x = _wrapTryCatchNonPublic.PrivateStaticStringProperty1;
        }

        private void SetupJustMock()
        {
            _wrapTryCatchNonPublic = Mock.NonPublic.Wrap(_tryCatch);
            _mockTryCatch = Mock.Create<TryCatchThrowExample>();
        }
    }
}
