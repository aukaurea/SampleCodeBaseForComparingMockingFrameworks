using System;
using System.Threading;

namespace SampleCodeBase.MemoryLeakExample
{
    public class DisposableWithMemoryLeak : IDisposable
    {
        private readonly Timer _timer;

        public DisposableWithMemoryLeak()
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
            // Timer is not disposed here, causing a memory leak
        }
    }
}