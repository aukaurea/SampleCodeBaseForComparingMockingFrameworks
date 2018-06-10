using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesTestProject.Tests
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
