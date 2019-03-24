using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SampleCodeBase.Helpers;
using SampleCodeBase.StaticType;

namespace SampleCodeBase.MethodPropertiesWithBusinessValue
{
    public class SampleGetterValue{
        public IRequiredPrep Required1 { get; }

        public SampleGetterValue(IRequiredPrep required, string w, IList<string> list)
        {
            Required1 = required;
        }

        public SampleGetterValue(
                ICollection<string> collection)
        { }

        public int GetGetterInt()
        {
            return Guid.NewGuid().GetHashCode();
        }

        public int GetGetterIntRandom2()
        {
            return Guid.NewGuid().GetHashCode() + GetGetterInt();
        }

        public int GetGetterIntRandom2(IRequiredPrep ir, string x)
        {
            return Guid.NewGuid().GetHashCode() + GetGetterInt();
        }
    }

    internal static class ConstSwitch
    {
        public const string Sw1 = "Sw1";
        public const string Sw2 = "Sw2";
        public const string Sw3 = "Sw3";
        public const string Sw4 = "Sw4";
        public readonly static ICollection<string> StringCollection = new List<string>(5);

        internal struct Const2Switch
        {
            public const string Sw5 = "Sw5";
            public const string Sw6 = "Sw6";

            internal struct Const3Switch
            {
                public const string Sw5 = "Sw5";
                public const string Sw6 = "Sw6";

                internal struct Const4Switch
                {
                    public const string Sw5 = "Sw5";
                    public const string Sw6 = "Sw6";
                }
            }


        }
    }

    public class SwitchCaseBlockExample
    {
        public readonly SampleGetterValue SampleGetterValue1 = new SampleGetterValue(new RequiredPrep(), String.Empty, new List<string>());
        private readonly SampleGetterValue PrivateSampleGetterValue2 = new SampleGetterValue(new RequiredPrep(), String.Empty, new List<string>());
        private List<string> _fieldListString;

        private SampleGetterValue GetNewSampleGetterValue(string str)
        {
            return new SampleGetterValue(new RequiredPrep(), str, _fieldListString);
        }

        public SwitchCaseBlockExample()
        {
            _fieldListString = new List<string>();
        }

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

        public void SwitchCaseExampleStringEx1(string x)
        {
            switch (x)
            {
                case "Hello World":
                    Console.WriteLine("example1");
                    Exmaple1();

                    break;

                case "Hello World2":
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;


                case "Hello World3":
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;

                default:
                    Console.WriteLine("default");
                    Exmaple1();

                    break;
            }
        }

        public void SwitchCaseExampleStringEx2(string x)
        {
            switch (x)
            {
                case ConstSwitch.Sw1:
                    Console.WriteLine("example1");
                    Exmaple1();


                    break;

                case ConstSwitch.Sw2:
                    Console.WriteLine("example2");
                    Exmaple1();

                    break;


                case ConstSwitch.Sw3:
                    Console.WriteLine("example3");
                    Exmaple1();

                    break;

                case ConstSwitch.Sw4:
                    Console.WriteLine("example4");
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
            var xw = ir.SampleMethodString();
            var xw22String = ir.SampleMethodString(ir, 1 + (string) 2.ToString() + xw + "" as string + _fieldListString.FirstOrDefault(), DateTime.Now, ir);
            var w1 = new SampleGetterValue(ir, 1 + (string) 2.ToString() + xw + "" as string + _fieldListString.FirstOrDefault(), _fieldListString);
            var sringArr = new string[23];
            var intArrr = new int[10];
            var intList = new List<int>(1);

            var w = w1.GetGetterInt();
            var w3 = w1.GetGetterIntRandom2();

            switch (w1.GetGetterInt())
            {
                case (int) ExampleEnum1.Example1:
                    Console.WriteLine("example1");
                    var ir2 = new RequiredPrep();
                    var xw2 = ir.SampleMethodString();
                    var w12 = new SampleGetterValue(ir2, xw2 + string.Empty, _fieldListString);
                    var w1332 = new SampleGetterValue(ConstSwitch.StringCollection);
                    var mDifferentW12Getting = w12.GetGetterInt();
                    var ard = ConstSwitch.Sw1;
                    var actualGetterValue = this.GetNewSampleGetterValue("23233223" + ConstSwitch.Sw1);
                    var actualGetterValue2 = this.GetNewSampleGetterValue(
                            "23233223" + ConstSwitch.Sw1);

                    var md = ConstSwitch.Const2Switch.Sw5;
                    var md2 = ConstSwitch.Const2Switch.Const3Switch.Const4Switch.Sw5;

                    var w33 = md2.ToString();

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
