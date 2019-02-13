using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleCodeBase.Helpers;
using SampleCodeBase.StaticType;

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

        public void SwitchCaseExample2()
        {
            var enum1 = GetRandomEnumValue();
            switch (enum1)
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

        public ExampleEnum1 GetRandomEnumValue()
        {
            var result = EnumHelper.GetRandomEnum<ExampleEnum1>();

            return result;
        }

        public void Exmaple1()
        {
            Console.WriteLine("Example1");
        }
    }
}
