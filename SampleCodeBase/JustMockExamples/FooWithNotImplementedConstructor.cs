using System;

namespace SampleCodeBase.JustMockExamples
{
    public class FooWithNotImplementedConstructor
    {
        public FooWithNotImplementedConstructor()
        {
            throw new NotImplementedException();
        }
    }
}