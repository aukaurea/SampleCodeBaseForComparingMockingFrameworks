using System;

namespace SampleCodeBase.DependencyInjection
{
    public class ClassUsingMethodOfInjectedService
    {
        private readonly IServiceInterface _service;

        public ClassUsingMethodOfInjectedService(IServiceInterface service)
        {
            _service = service;
        }
=
        public bool MethodCallingInjectedServiceMethodReturningBoolean()
        {
            if (_service.IsValid())
            {
                Console.WriteLine(1);
                return true;
            }
            else
            {
                Console.WriteLine(2);
                return false;
            }
        }

        public void MethodCallingInjectedServiceMethodReturningIntUsedInEqualsCondition()
        {
            if (_service.GetCount() == 1)
            {
                Console.WriteLine(1);
            }
        }

        public void MethodCallingInjectedServiceMethodReturningIntUsedInGreaterThanOrEqualsCondition()
        {
            if (_service.GetCount() >= 1)
            {
                Console.WriteLine(1);
            }
        }

        public void MethodCallingInjectedServiceMethodReturningStringUsedInEqualsCondition()
        {
            if (_service.GetName() == "Maria")
            {
                Console.WriteLine(1);
            }
        }

        public bool MethodCallingInjectedServiceMethodReturningReferenceType()
        {
            if (_service.GetFoo() != null)
            {
                return true;
            }

            return false;
        }

        //public void Do()
        //{
        //    _service.Do();

        //    // Do stuff
        //}
    }
}