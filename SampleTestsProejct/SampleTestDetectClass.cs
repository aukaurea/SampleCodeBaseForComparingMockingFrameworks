using System;

namespace SampleTestsProejct
{
    public class SampleTestDetectClass
    {
        public string StringProperty1 { get; set; }
        private string PrivateStringProperty1 { get; set; }
        private static string PrivateStaticStringProperty1 { get; set; }
        private DateTime PrivateDateTimeProperty1 { get; set; }

        public SampleTestDetectClass(string p1, string p2, DateTime d1)
        {
            StringProperty1 = p1;
            PrivateStaticStringProperty1 = p2;
            PrivateDateTimeProperty1 = d1;
        }

        public SampleTestDetectClass(string p2, DateTime d1)
        {
            StringProperty1 = p2;
            PrivateDateTimeProperty1 = d1;
        }

        public SampleTestDetectClass(DateTime d1)
        {
            PrivateDateTimeProperty1 = d1;
            PrivateStringProperty1 = "";
        }

        public SampleTestDetectClass(DateTime d1, string p1)
        {
            PrivateDateTimeProperty1 = d1;
            PrivateStringProperty1 = "";

            if (p1 == null)
            {
                PrivateStringProperty1 = "Null Set";
            }
        }
    }
}