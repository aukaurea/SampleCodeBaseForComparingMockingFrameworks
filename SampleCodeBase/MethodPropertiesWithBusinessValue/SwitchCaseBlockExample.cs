using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleCodeBase.Helpers;
using SampleCodeBase.StaticType;

namespace SampleCodeBase.MethodPropertiesWithBusinessValue
{
    public class SampleGetterValue{

        public SampleGetterValue(IRequiredPrep required)
        {
            
        }

        public int GetGetterInt()
        {
            return Guid.NewGuid().GetHashCode();
        }

        public int GetGetterIntRandom2()
        {
            return Guid.NewGuid().GetHashCode() + GetGetterInt();
        }
    }

    public class SwitchCaseBlockExample
    {
        public SwitchCaseBlockExample()
        { }

        public void SwitchCaseExample5(int? x)
        {
            switch (x.Value)
            {
                case (int) ExampleEnum1.Example1:
                    Console.WriteLine("example1");
                    Exmaple1();

                    break;

                case (int) ExampleEnum1.Example2:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;


                case (int) ExampleEnum1.Example3:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;

                default:
                    Console.WriteLine("default");
                    Exmaple1();

                    break;

            }
        }

        public void SwitchCaseExample6(int? x)
        {
            var ir = new RequiredPrep();
            var w1 = new SampleGetterValue(ir);

            var w = w1.GetGetterInt();
            var w3 = w1.GetGetterIntRandom2();

            switch (w)
            {
                case (int) ExampleEnum1.Example1:
                    Console.WriteLine("example1");
                    Exmaple1();

                    break;

                case (int) ExampleEnum1.Example2:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;


                case (int) ExampleEnum1.Example3:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;

                default:
                    Console.WriteLine("default");
                    Exmaple1();

                    break;

            }


            switch (w3)
            {
                case (int) ExampleEnum1.Example1:
                    Console.WriteLine("example1");
                    Exmaple1();

                    break;

                case (int) ExampleEnum1.Example2:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;


                case (int) ExampleEnum1.Example3:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;

                default:
                    Console.WriteLine("default");
                    Exmaple1();

                    break;

            }
        }

        public void SwitchCaseExample1(int x)
        {
            switch (x)
            {
                case 1:
                    Console.WriteLine("example1");
                    Exmaple1();

                    break;

                case 2:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;


                case 3:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;

                default:
                    Console.WriteLine("default");
                    Exmaple1();

                    break;

            }
        }

        public void SwitchCaseExample1(short x)
        {
            switch (x)
            {
                case 1:
                    Console.WriteLine("example1");
                    Exmaple1();

                    break;

                case 2:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;


                case 3:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;

                default:
                    Console.WriteLine("default");
                    Exmaple1();

                    break;

            }
        }

        public void SwitchCaseExample1(long x)
        {
            switch (x)
            {
                case 1:
                    Console.WriteLine("example1");
                    Exmaple1();

                    break;

                case 2:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;


                case 3:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;

                default:
                    Console.WriteLine("default");
                    Exmaple1();

                    break;

            }
        }

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

        public void ForLoopExample1(int a, int b)
        {
            for (var i = 0; i < a && a < b; i++)
            {
                Console.WriteLine(i);
            }
        }

        public void Exmaple1()
        {
            Console.WriteLine("Example1");
        }
    }
}
