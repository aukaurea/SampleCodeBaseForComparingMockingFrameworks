using System;

namespace SampleCodeBase.MethodPropertiesWithBusinessValue
{
    /// <summary>
    /// 100% blocks needs to be covered with business logic
    /// </summary>
    public class ClassWithBusinessLogic2 : IRequired, IRequiredPrep
    {
        private RequiredPrep _requiredPrep;
        private ClassWithBusinessLogic _classWithBusinessLogic;
        private Required _required;

        public ClassWithBusinessLogic2()
        {
            _requiredPrep = new RequiredPrep();
            _required = new Required();
            _classWithBusinessLogic = new ClassWithBusinessLogic(_required, _requiredPrep);
        }

        #region Implementation of IRequired

        public string RequiredStringProp { get; set; }

        public DateTime RequiredDateTimeProp { get; set; }

        public void SampleMethod(IRequiredPrep prep)
        {
            // Remember there is not possibility of having the same method name like this.
            // This is just an example. So don't hard code anything.
            prep.SampleMethod();
        }

        public string SampleMethodString(IRequiredPrep prep)
        {
            // Remember there is not possibility of having the same method name like this.
            // This is just an example. So don't hard code anything.
            return prep.SampleMethodString();
        }

        #endregion

        #region Implementation of IRequiredPrep

        public void SampleMethod()
        {
            // Remember there is not possibility of having the same method name like this.
            // This is just an example. So don't hard code anything.
            this.SampleMethod(_requiredPrep);
        }

        public string SampleMethodString()
        {
            // You need to add these (constructor, since it is initialized in the constructor)
            // Remember there is not possibility of having the same method name like this.
            // This is just an example. So don't hard code anything.
            return this.SampleMethodString(_requiredPrep);
        }

        #endregion
    }
}
