using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleCodeBase.MethodPropertiesWithBusinessValue;

namespace SampleCodeBase.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new SwitchCaseBlockExample();

            var x = sw.GetRandomEnumValue();

            System.Console.WriteLine(x);
        }
    }
}
