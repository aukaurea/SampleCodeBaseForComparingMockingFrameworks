using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestsProejct
{
    internal class FooInternalStatic
    {
        private static int EchoPrivate(int arg1)
        {
            throw new NotImplementedException();
        }

        public static int Echo(int arg1)
        {
            return EchoPrivate(arg1);
        }
    }
}
