using System;
using System.Collections.Generic;

namespace SampleCodeBase.JustMockExamples
{
    public class FooVirtual
    {
        public FooVirtual()
        {
            throw new NotImplementedException("Constructor");
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual void VoidMethod()
        {
            throw new NotImplementedException();
        }

        public virtual IList<int> GetList()
        {
            throw new NotImplementedException();
        }
    }
}