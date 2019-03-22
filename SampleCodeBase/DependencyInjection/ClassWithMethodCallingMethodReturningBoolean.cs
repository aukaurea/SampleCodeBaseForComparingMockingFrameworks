using System;

namespace SampleCodeBase.DependencyInjection
{
    public class ClassWithMethodCallingMethodReturningBoolean
    {
        private readonly IServiceInterface _service;

        public ClassWithMethodCallingMethodReturningBoolean(IServiceInterface service)
        {
            _service = service;
        }

        // detect this
        public void DoMethod()
        {
            if (_service.IsValid())
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(2);
            }
        }

        public bool IsValid()
        {
            return _service.IsValid();
        }
    }
}