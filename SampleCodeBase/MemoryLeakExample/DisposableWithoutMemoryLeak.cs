using System;
using System.Threading;

namespace SampleCodeBase.MemoryLeakExample
{
    public class DisposableWithoutMemoryLeak : IDisposable
    {
        private readonly Timer _timer;

        public DisposableWithoutMemoryLeak()
        {
            _timer = new Timer(Tick);
            _timer.Change(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
        }

        private static void Tick(object state)
        {
            Console.WriteLine("Tick");
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}