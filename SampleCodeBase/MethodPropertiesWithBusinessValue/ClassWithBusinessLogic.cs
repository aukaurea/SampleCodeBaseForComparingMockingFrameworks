using System;

namespace SampleCodeBase.MethodPropertiesWithBusinessValue
{
    /// <summary>
    /// 100% blocks needs to be covered with business logic
    /// </summary>
    public class ClassWithBusinessLogic
    {
        private IRequired _required;
        private IRequiredPrep _requiredPrep;
        private string _publicStringProp;
        private ClassWithProperties _classWithProperties;
        private ClassWithMethods _classWithMethods;

        public ClassWithBusinessLogic(IRequired required)
        {
            _required = required;
        }

        public ClassWithBusinessLogic(IRequired required, IRequiredPrep requiredPrep)
        {
            // You need to add these steps as fakes it could be real steps to call a method or property.
            _required = required;
            _requiredPrep = requiredPrep;
            _classWithProperties = new ClassWithProperties(_required);
            _classWithMethods = new ClassWithMethods(_required);
        }

        public string PublicStringProp
        {
            get => _classWithProperties.PublicStringProp;
            set => _classWithProperties.PublicStringProp = value;
        }

        public string PrivateStringProp { get; internal set; }

        private DateTime? PrivateDateProp { get; set; }

        private int? PrivateIntProp { get; set; } = 100;

        private byte? PrivateByteProp { get; set; } = 54;

        public long? PubliceByteProp
        {
            get => _classWithProperties.PubliceByteProp;
            set => _classWithProperties.PubliceByteProp = value;
        }

        public DateTime GetDynamicDate()
        {
            return DateTime.Now.Date;
        }

        public DateTime GetDynamicDate(IRequired required)
        {
            return DateTime.Now.Date;
        }

        public void BusinessLogicExampleOfSameplemethod()
        {
            // You need to add these steps as fakes it could be real steps to call a method or property.
            // You need to add these (constructor, since it is initialized in the constructor) steps with MS Fakes.
            var xDate = GetDynamicDate();
            var xDate2 = GetDynamicDate(_required);
            _required.RequiredDateTimeProp = xDate;
            _required.RequiredStringProp = xDate2.ToLongDateString();

            _required.SampleMethod(_requiredPrep);
        }

        public string BusinessLogicExampleOfSamepleMethodString()
        {
            // You need to add these steps as fakes it could be real steps to call a method or property.
            // You need to add these (constructor, since it is initialized in the constructor) steps with MS Fakes.

            // Below 3 lines capture in a private method.
            var xDate = GetDynamicDate();
            var xDate2 = GetDynamicDate(_required);
            _required.RequiredDateTimeProp = xDate;
            //  Common parts should be setup from one private method and all other parts should be configured for each method.
            var number1 = xDate.Second + xDate2.Second;
            _required.RequiredStringProp = number1.ToString();

            return _required.SampleMethodString(_requiredPrep);
        }
    }
}
