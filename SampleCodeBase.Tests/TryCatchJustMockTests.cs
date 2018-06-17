using System;
using NUnit.Framework;
using SampleCodeBase.JustMockExamples;
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
        public void ShouldInvokeNonPublicMemberDynamic()
        {
            // Arrange
            Mock.Arrange(() => new Foo()).DoNothing();
            Foo foo = new Foo();
            dynamic fooAcc = Mock.NonPublic.Wrap(foo);
            Mock.NonPublic.Arrange<int>(fooAcc.PrivateEcho(ArgExpr.IsAny<int>())).Returns(10);
            Mock.NonPublic.Arrange<string>(fooAcc.Value).Returns("foo");
            Mock.NonPublic.Arrange(fooAcc.Value = "abc").OccursOnce();

            // Act
            var actual = foo.Echo(5);
            var value = foo.GetType().GetField("Value");

            // Assert
            Assert.AreEqual(10, actual);
            Assert.AreEqual("foo", value);
            Mock.Assert(foo);
        }


        [Test]
        public void DatabaseCallPauseFor30SecondsAndThrowsReturnsTrueTests()
        {
            // Arrange
            SetupJustMock();
            Mock.NonPublic.Arrange<string>(typeof(TryCatchThrowExample), "PrivateStaticStringProperty1").Returns(string.Empty);


            // Act, Assert
            //PrivateMethod()
            var x = TryCatchThrowExample.PrivateStaticStringProperty1Get;
            var y = x;
        }

        private void SetupJustMock()
        {
            _wrapTryCatchNonPublic = Mock.NonPublic.Wrap(_tryCatch);
            _tryCatch =  new TryCatchThrowExample();
            _mockTryCatch = Mock.Create<TryCatchThrowExample>();
        }
    }
}
