namespace SampleCodeBase.DependencyInjection
{
    public class ClassWithMethodCallingMethodReturningReferenceType
    {
        private readonly IServiceInterface _service;

        public ClassWithMethodCallingMethodReturningReferenceType(IServiceInterface service)
        {
            _service = service;
        }

        // detect this
        public void DoMethod()
        {
            var foo = _service.GetFoo();
            foo.ToString();
        }
    }
}