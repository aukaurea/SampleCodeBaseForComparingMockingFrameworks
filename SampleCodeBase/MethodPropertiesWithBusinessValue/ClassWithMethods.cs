using System;

namespace SampleCodeBase.MethodPropertiesWithBusinessValue
{
    public class ClassWithMethods : IRequired
    {
        private IRequired _required;

        public ClassWithMethods(IRequired required)
        {
            _required = required;
        }

        public string PublicStringProp { get; set; }

        private string PrivateStringProp { get; set; }

        private DateTime? PrivateDateProp { get; set; }

        private int? PrivateIntProp { get; set; } = 5;

        private byte? PrivateByteProp { get; set; } = 5;

        public long? PubliceByteProp { get; set; } = 5;

        #region Implementation of IRequired


        public string RequiredStringProp
        {
            get => _required.RequiredStringProp;
            set => _required.RequiredStringProp = value;
        }

        public DateTime RequiredDateTimeProp { get; set; }

        public void SampleMethod(IRequiredPrep prep)
        {
            prep.SampleMethod();
        }

        public string SampleMethodString(IRequiredPrep prep)
        {
            return prep.SampleMethodString();
        }

        #endregion
    }
}
