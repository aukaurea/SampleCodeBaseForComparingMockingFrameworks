using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsControlLibrary1;
using NUnit.Framework;
using SampleWindowsForm;
using SampleWPF;
using Shouldly;
using WpfControlLibrary1;

namespace SampleCodeBase.Tests
{
    [TestFixture]
    public class WinFromsWPFTest
    {
        private Page1 _page;
        private Form1 _form;
        private WinControl1 _winUserControl1;
        private WPFControl1 _wpfUserControl1;

        public WinFromsWPFTest()
        {
            _page = new Page1();
            _form = new Form1();
            _winUserControl1 = new WinControl1();
            _wpfUserControl1 = new WPFControl1();
        }

        [Test]
        public void SampleTest()
        {
            _page.ShouldNotBeNull();
            _form.ShouldNotBeNull();
            _winUserControl1.ShouldNotBeNull();
            _wpfUserControl1.ShouldNotBeNull();
        }
    }
}
