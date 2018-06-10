using System;
using Microsoft.QualityTools.Testing.Fakes;
using NUnit.Framework;
using SampleCodeBase.Fakes;

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

            // Act, Assert
            //PrivateMethod()
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
