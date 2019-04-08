using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCodeBase.DelegateExamples
{
    public class NonVoidDelegate
    {
        public string GetNonDelegateExample(int a, int b)
        {
            var x = GetNonDelegateExample2(a, b);

            return x;
        }
        public string GetNonDelegateExample2(int a, int b) => (a + b).ToString();
    }
}
