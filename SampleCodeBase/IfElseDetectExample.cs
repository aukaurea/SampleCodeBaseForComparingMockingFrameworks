using System;
using System.Collections.Generic;

namespace SampleCodeBase
{
    public class IfElseDetectExample
    {
        public string StringProperty1 { get; set; }
        private string PrivateStringProperty1 { get; set; }
        private static string PrivateStaticStringProperty1 { get; set; }
        private DateTime PrivateDateTimeProperty1 { get; set; }
        private List<DateTime> PrivateListDateTimeProperty1 { get; set; }

        public void MethodWithIfBlock(string p1, string p2)
        {
            // detect this.
            if (p2 == null && p1 == PrivateStringProperty1 || PrivateDateTimeProperty1.Equals(null))
            {
                // do stuff.
                // need to cover this block
                // need to fake or moq the string.IsNullOrEmpty
            }
            else
            {
                // else part
            }
        }

        private bool ReturnsFalse()
        {
            return false;
        }

        private bool ReturnsFalse(Action action)
        {
            return false;
        }

        private bool ReturnsFalse(IfElseDetectExample ifElseDetectExample)
        {
            return false;
        }

        public void MethodWithIfBlock()
        {
            // detect this.
            if (string.IsNullOrEmpty(StringProperty1))
            {
                // do stuff.
                // need to cover this block
            }
            else
            {
                // else part
            }

            // detect this.
            var condition1 = ReturnsFalse();
            var condition2 = PrivateListDateTimeProperty1 == null;
            var condition3 = string.IsNullOrEmpty(StringProperty1);
            var condition4 = ReturnsFalse(()=> ReturnsFalse());
            var condition5 = ReturnsFalse(new IfElseDetectExample());
            var finalCondition = condition1 && condition2 || condition3 || condition4 && condition5;

            if (finalCondition && condition3 && DateTime.Parse("1-Mar-2018") == DateTime.Now)
            {
                // do stuff.
                // need to cover this block
            }
            else
            {
                // else part
            }
        }
    }
}