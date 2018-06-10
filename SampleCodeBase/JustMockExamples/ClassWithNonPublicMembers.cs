namespace SampleCodeBase.JustMockExamples
{
    public class ClassWithNonPublicMembers
    {
        private int Prop { get; set; }

        private int MePrivate()
        {
            return 1000;
        }

        private static int MeStaticPrivate()
        {
            return 2000;
        }
    }
}