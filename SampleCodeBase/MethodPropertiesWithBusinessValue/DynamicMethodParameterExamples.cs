using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleCodeBase.StaticType;

namespace SampleCodeBase.MethodPropertiesWithBusinessValue
{
    public class DynamicMethodParameterExamples
    {
        public void XampleMethod1(dynamic p1, dynamic p2, int x, bool y)
        {
            if (p1 == p2)
            {
                Console.WriteLine("p1 == p2");
                Console.WriteLine("p1 == p2");
                Console.WriteLine("p1 == p2");
            }
            else
            {
                Console.WriteLine("p1 != p2");
            }

            if (p2 == x)
            {
                Console.WriteLine("p2 == x");
                Console.WriteLine("p2 == x");
                Console.WriteLine("p2 == x");
            }


            if (p1 == x)
            {
                Console.WriteLine("p1 == x");
                Console.WriteLine("p1 == x");
                Console.WriteLine("p1 == x");
            }

            if (p1 == y)
            {
                Console.WriteLine("p1 == y");
                Console.WriteLine("p1 == y");
                Console.WriteLine("p1 == y");
            }
        }

        public void XampleMethod2(dynamic p1, dynamic p2, int x, bool y)
        {
            var md = (IRequired) p1;
            var md2 = (IRequiredPrep) p2;

            XampleMethod1("Hello", "Hello", 2, y == false);
            XampleMethod1("Hello", "Hello", 1, y == false);
            XampleMethod1("Hello", 1, 1, y == false);
            XampleMethod1("Hello", p2, p1, y == false);
            XampleMethod1(2, 1, 1, y == false);
            XampleMethod1(md, md2, 1, false);
            XampleMethod1(md, md2, 1, y == false);
            XampleMethod1(md2, md, 1, y == false);
            XampleMethod1("Hello", "Hello", 1, y == false);
        }

        public void XampleMethod3(dynamic p1)
        {
           Console.WriteLine(p1);
        }

        public void XampleMethod3(dynamic p1, IRequired example)
        {
            Console.WriteLine(p1);
        }

        public void XampleMethod3(dynamic p1, IRequired example, IRequiredPrep rp)
        {
            Console.WriteLine(p1);
        }

        public void XampleMethod3(ExampleEnum1 exampleEnum1, IRequired example, IRequiredPrep rp)
        {
            Console.WriteLine(exampleEnum1);
        }

        public void XampleMethod3(ExampleEnum1 exampleEnum1, dynamic example)
        {
            Console.WriteLine(exampleEnum1);
        }
    }
}
