using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SampleCodeBase.Helpers
{
    internal class ReflectionTypeHelper
    {
        public static Type GetTypeByString(string fullyQuantifiedName)
        {

            var type = Assembly.GetType(fullyQuantifiedName, false, false);

            return type;
        }
    }
}
