using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.QualityTools.Testing.Fakes;
using NUnit.Framework;
using SampleCodeBase.Fakes;
using SampleCodeBase.JustMockExamples;
using SampleCodeBase.JustMockExamples.Fakes;
using Telerik.JustMock;

namespace SampleCodeBase.Tests
{
    [TestFixture]
    public class TryCatchFakesTests
    {
        private IDisposable _shimsContext;
        private TryCatchThrowExample _tryCatch;
        private readonly DateTime ConstDateTime = new DateTime(2009, 1, 20);

        [SetUp]
        public void Init()
        {
            _tryCatch = new TryCatchThrowExample();
            _shimsContext = ShimsContext.Create();
        }

        [TearDown]
        public void CleanUp()
        {
            _shimsContext.Dispose();
        }

        [Test]
        public void TryCatchUsingMSFakesTest()
        {
            // Arrange
            SetupFakes();

            // Act, Assert
            _tryCatch.TryCatchWithThrowExample();
        }

        [Test]
        public void TryCatchParametersUsingMSFakesTest()
        {
            // Arrange
            SetupFakes();

            // Act, Assert
            _tryCatch.TryCatchWithThrowExample("", "");
        }

        [Test]
        public void CatchParametersUsingMSFakesTest()
        {
            // Arrange
            SetupFakes();
            ShimTryCatchThrowExample.PrivateStaticStringProperty1Get = () =>
            {
                throw new ArgumentException();
                return string.Empty;
            };

            // Act, Assert
            _tryCatch.TryCatchWithThrowExample("", "");
        }


        [Test]
        public void DatabaseCallPauseFor30SecondsAndThrowsReturnsTrueTests()
        {
            // Arrange
            SetupFakes();
            ShimTryCatchThrowExample.PrivateStaticStringProperty1Get = () =>
            {
                throw new ArgumentException();
                return string.Empty;
            };

            // Assert
            //PrivateMethod()
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

        private void SetupFakes()
        {
            ShimTryCatchThrowExample.AllInstances.DatabaseCallPauseFor30SecondsAndThrows = x => { };

            ShimTryCatchThrowExample.AllInstances.DatabaseCallPauseFor30SecondsAndThrows = x => { };
            ShimTryCatchThrowExample.AllInstances.DatabaseCallPauseFor30SecondsAndThrowsReturnsTrue = x => true;
            ShimTryCatchThrowExample.AllInstances.MethodThrows = x => { };
            ShimTryCatchThrowExample.AllInstances.MethodThrowsException = (w, x) => { };
            ShimTryCatchThrowExample.AllInstances.MethodThrowsNew = (w) => { };
            ShimTryCatchThrowExample.AllInstances.PrivateDateTimeProperty1Get = (x) => ConstDateTime;
            ShimTryCatchThrowExample.AllInstances.PrivateDateTimeProperty1SetDateTime = (x, y) => { };
            ShimTryCatchThrowExample.AllInstances.PrivateListDateTimeProperty1SetListOfDateTime = (x, y) => { };
            ShimTryCatchThrowExample.AllInstances.PrivateStringProperty1Get = (x) => "";
            ShimTryCatchThrowExample.AllInstances.PrivateStringProperty1SetString = (x, y) => { };
            ShimTryCatchThrowExample.AllInstances.StringProperty1Get = (x) => "";
            ShimTryCatchThrowExample.AllInstances.StringProperty1SetString = (x, y) => { };
            //ShimTryCatchThrowExample.AllInstances.TryCatchWithThrowExampleStringString = (x, y, w) => { };
            //ShimTryCatchThrowExample.AllInstances._TryCatchWithThrowExampleb__30_0 = (x) => { };
            ShimTryCatchThrowExample.AllInstances.ReturnsAndThrowsFalse = (x) => true;
            ShimTryCatchThrowExample.AllInstances.ReturnsFalse = (x) => true;
            ShimTryCatchThrowExample.AllInstances.ReturnsFalseAction = (x, w) => true;
        }
    }
}
