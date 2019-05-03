using SampleCodeBase.GenericClass;

namespace Sample.ClassLib
{
    public class Class1
    {
        public void Test()
        {
            var example = new GenericArgumentExamples<LocalArgumentExample>();
            example.MethodWithComplexParameters<int, double>(null, null, null, null, null, null, null, null, null);
        }
    }

    class LocalArgumentExample : IGenericArgumentExample1<decimal, string>
    {
        public string S1 { get; set; }
        public string S2 { get; set; }
        public decimal T1x { get; set; }
        public string T2x { get; set; }
    }
}
