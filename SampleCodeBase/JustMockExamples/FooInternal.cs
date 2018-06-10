using System;

namespace SampleCodeBase.JustMockExamples
{
    internal class FooInternal
    {
        private void pExecute(int arg1)
        {
            throw new NotImplementedException();
        }

        private void pExecute()
        {
            throw new NotImplementedException();
        }

        public void Execute(int arg1)
        {
            pExecute(arg1);
        }

        public void Execute()
        {
            pExecute();
        }
    }
}