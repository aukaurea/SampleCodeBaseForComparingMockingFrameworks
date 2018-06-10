using System;

namespace SampleCodeBase.JustMockExamples
{
    public partial class Foo
    {
        public class FooGeneric
        {
            public TRet Echo<T, TRet>(T arg1)
            {
                throw new NotImplementedException();
            }
        }
    }
}