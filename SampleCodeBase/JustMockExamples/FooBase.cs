using System;

namespace SampleCodeBase.JustMockExamples
{
    public class FooBase : IManager
    {
        object IManager.Provider
        {
            get => throw new NotImplementedException();
        }
    }
}