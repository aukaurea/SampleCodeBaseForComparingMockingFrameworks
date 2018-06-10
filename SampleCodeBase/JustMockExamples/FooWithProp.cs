namespace SampleCodeBase.JustMockExamples
{
    public class FooWithProp
    {
        public string MyProp { get; set; }
        public FooWithProp GetNewInstance()
        {
            return new FooWithProp();
        }
    }
}