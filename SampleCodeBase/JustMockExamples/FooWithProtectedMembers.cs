using System;

namespace SampleCodeBase.JustMockExamples
{
    public class FooWithProtectedMembers
    {
        protected virtual int IntValue
        {
            get => throw new NotImplementedException();
        }

        protected virtual void Load()
        {
            throw new NotImplementedException();
        }

        public virtual void Init()
        {
            Load();
        }
    }
}