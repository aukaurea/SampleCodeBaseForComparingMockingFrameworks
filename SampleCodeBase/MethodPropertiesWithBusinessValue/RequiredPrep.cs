using System.Collections.Generic;

namespace SampleCodeBase.MethodPropertiesWithBusinessValue
{
    /// <summary>
    /// This is bad practice to keep multiple definition in the same file.
    /// It has been placed intentionally for detecting purpose.
    /// </summary>
    public class RequiredPrep : IRequiredPrep
    {
        private List<string> _list;

        #region Implementation of IRequiredPrep

        public void SampleMethod()
        {
            // Remember there is not possibility of having the same method name like this.
            // This is just an example. So don't hard code anything.

            // Let's do crazy stuff here.
            _list = new List<string>(200);
            _list.Add("Sample");

            Utility.ThrowException();
            Utility.ThrowException("Hello World");

            _list.Add("Sample");
            _list.Add("Sample2");
            _list.Add("Sampl3");
            _list.Add("Sample4");
            _list.Add("Sample5");
            _list.Add("Sample6");

            Utility.ArgumentException(string.Empty);
            Utility.ArgumentException(string.Empty);
            Utility.ArgumentException(string.Empty);
            Utility.ArgumentException(string.Empty);

            _list.Add("Sample");
            _list.Add("Sample2");
            _list.Add("Sampl3");
            _list.Add("Sample4");
            _list.Add("Sample5");
            _list.Add("Sample6");
        }

        public string SampleMethodString()
        {

            // Let's do crazy stuff here.
            _list = new List<string>(200);
            _list.Add("Sample");

            Utility.ThrowException();
            Utility.ThrowException("Hello World");

            _list.Add("Sample");
            _list.Add("Sample2");
            _list.Add("Sampl3");
            _list.Add("Sample4");
            _list.Add("Sample5");
            _list.Add("Sample6");

            Utility.ArgumentException(string.Empty);
            Utility.ArgumentException(string.Empty);
            Utility.ArgumentException(string.Empty);
            Utility.ArgumentException(string.Empty);

            _list.Add("Sample");
            _list.Add("Sample2");
            _list.Add("Sampl3");
            _list.Add("Sample4");
            _list.Add("Sample5");
            _list.Add("Sample6");

            return string.Join(", ", _list);
        }

        #endregion
    }
}
