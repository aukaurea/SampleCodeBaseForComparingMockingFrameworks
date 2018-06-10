using System;

namespace SampleCodeBase
{
    public class FooWithProtectedMembers
    {
        protected virtual void Load()
        {
            throw new NotImplementedException();
        }

        protected virtual int IntValue
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual void Init()
        {
            Load();
        }
    }
}
