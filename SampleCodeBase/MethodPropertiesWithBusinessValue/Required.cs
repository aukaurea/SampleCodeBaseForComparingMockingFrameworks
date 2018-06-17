using System;

namespace SampleCodeBase.MethodPropertiesWithBusinessValue
{
    /// <summary>
    /// This is bad practice to keep multiple definition in the same file.
    /// It has been placed intentionally for detecting purpose.
    /// </summary>
    public class Required : IRequired
    {
        #region Implementation of IRequired

        public string RequiredStringProp { get; set; } = string.Empty;

        public DateTime RequiredDateTimeProp { get; set; } = DateTime.Now;

        public void SampleMethod(IRequiredPrep prep)
        {
            prep.SampleMethod();
        }

        public string SampleMethodString(IRequiredPrep prep)
        {
            // Remember there is not possibility of having the same method name like this.
            // This is just an example. So don't hard code anything.
            return prep.SampleMethodString();
        }

        #endregion
    }
}
