using System.ComponentModel;

namespace SampleCodeBase.DependencyInjection
{
    public interface IServiceInterface
    {
        bool IsValid();

        bool IsEmpty();

        Foo GetFoo();
    }
}