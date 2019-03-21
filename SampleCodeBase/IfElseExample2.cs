using System;
using System.Collections.Generic;

namespace SampleCodeBase
{
    public class IfElseExample2
    {
        public string StringProperty1 { get; set; }
        private string PrivateStringProperty1 { get; set; }
        private static string PrivateStaticStringProperty1 { get; set; }
        private DateTime PrivateDateTimeProperty1 { get; set; }
        private List<DateTime> PrivateListDateTimeProperty1 { get; set; }
        public int? ExampleOfIntNullable { get; set; }
        public int? ExampleOfIntNullableGetOnly { get; }


        public void OneExample(int param1)
        {
            if (param1 == 10)
            {
                Console.WriteLine("10 is received.");
            }
            else if (param1 == 11)
            {
                Console.WriteLine("11 is received.");
            }
            else if (param1 == 12)
            {
                Console.WriteLine("12 is received.");
            }
            else if (param1 == 132)
            {
                Console.WriteLine("132 is received.");
            }
            else if (param1 >= 133)
            {
                Console.WriteLine("133 and above is received.");
            }
            else
            {
                Console.WriteLine("default.");
            }
        }

        public void TwoExample(int param1, int param2)
        {
            if (param1 <= 10)
            {
                OneExample(param1);
            }
            else if (param1 == 11)
            {
                OneExample(param2);
            }
            else if (param1 == 12 && param2 == 5)
            {
                OneExample(param2);
                Console.WriteLine("5 is received.");
                Console.WriteLine("12 is received.");
            }
            else
            {
                Console.WriteLine("default of two.");
            }
        }

        public void ThreeExample(int param1, int param2, int param3)
        {
            if (param1 <= param2)
            {
                OneExample(param1);
                TwoExample(param1, param2);
            }
            else if (param1 == 11)
            {
                TwoExample(param1, param2);
                OneExample(param2);
                TwoExample(param1, param2);
            }
            else if (param1 == 12 &&
                     param2 == 5 &&
                     param3 == 3)
            {
                Console.WriteLine("3 is received.");
                Console.WriteLine("5 is received.");
                Console.WriteLine("12 is received.");
                TwoExample(param1, param2);
                OneExample(param2);
                TwoExample(param1, param2);
                Console.WriteLine("Again call");
                ThreeExample(param1 + 1, param2, param3 - 1);
            }
            else
            {
                Console.WriteLine("default of three.");
            }
        }
    }
}