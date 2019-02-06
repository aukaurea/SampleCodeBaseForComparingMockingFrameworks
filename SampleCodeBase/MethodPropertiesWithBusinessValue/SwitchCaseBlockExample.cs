using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCodeBase.MethodPropertiesWithBusinessValue
{
    public class SwitchCaseBlockExample
    {
        public SwitchCaseBlockExample()
        {}

        public void SwitchCaseExample1(ExampleEnum1 exampleEnum1)
        {
            switch (exampleEnum1)
            {
                case ExampleEnum1.Example1:
                    Console.WriteLine("example1");
                    Exmaple1();
                    break;

                case ExampleEnum1.Example2:
                    Console.WriteLine("example2");
                    Exmaple1();
                    break;

                default:
                    Console.WriteLine("default");
                    Exmaple1();

                    break;

            }
        }

        public void Exmaple1()
        {
            Console.WriteLine("Example1");
        }
    }
}
