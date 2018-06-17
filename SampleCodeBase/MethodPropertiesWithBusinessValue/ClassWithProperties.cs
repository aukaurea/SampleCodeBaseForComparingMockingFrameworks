using System;

namespace SampleCodeBase.MethodPropertiesWithBusinessValue
{
    /// <summary>
    /// This is bad practice to keep multiple definition in the same file.
    /// It has been placed intentionally for detecting purpose.
    /// </summary>
    public interface IRequired
    {
        string RequiredStringProp { get; set; }

        DateTime RequiredDateTimeProp { get; set; }
        void SampleMethod(IRequiredPrep prep);
        string SampleMethodString(IRequiredPrep prep);
    }

    /// <summary>
    /// 100% blocks needs to be covered by business logic
    /// </summary>
    public class ClassWithProperties
    {
        private IRequired _required;

        public ClassWithProperties(IRequired required)
        {
            _required = required;
        }
        public string PublicStringProp { get; set; }
        private string PrivateStringProp { get; set; }
        private DateTime? PrivateDateProp { get; set; }

        private int? PrivateIntProp { get; set; } = 5;
        private byte? PrivateByteProp { get; set; } = 5;
        public long? PubliceByteProp { get; set; } = 5;
    }
}
