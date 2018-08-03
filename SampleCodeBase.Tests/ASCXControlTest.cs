using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Shouldly;
using WebApplication1.UserControls;

namespace SampleCodeBase.Tests
{
    [TestFixture]
    public class ASCXControlTest
    {
        private WebUserControl1 _control;

        public ASCXControlTest()
        {
            _control = new WebUserControl1();
        }

        [Test]
        public void SampleTest()
        {
            _control.ShouldNotBeNull();
        }
    }
}
