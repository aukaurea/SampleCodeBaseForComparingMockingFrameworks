using System;
using System.Collections.Generic;

namespace SampleCodeBase.JustMockExamples
{
    public partial class Foo : IFoo
    {
        public delegate void EchoEventHandler(bool echoed);

        static Foo()
        {
            throw new NotImplementedException();
        }

        public static int FooProp
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public List<object> RealCollection { get; }

        internal virtual string Value
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        private static int PrivateStaticProperty { get; set; }

        public void Execute()
        { }

        public void Execute(int arg)
        {
            DoPrivate(arg);
        }

        public static void Submit()
        { }

        public int Execute(int arg1, int arg2)
        {
            throw new NotImplementedException();
        }

        public event EchoEventHandler OnEchoCallback;

        public IList<object> FakeCollection()
        {
            var resultCollection = new List<object>();

            resultCollection.Add("asd");
            resultCollection.Add(123);
            resultCollection.Add(true);

            return resultCollection;
        }

        private void DoPrivate()
        {
            throw new NotImplementedException();
        }

        private void DoPrivate(int arg)
        {
            throw new NotImplementedException();
        }

        public void DoPublic()
        {
            DoPrivate();
        }

        private int PrivateEcho(int arg)
        {
            return arg;
        }

        public int Echo(int arg)
        {
            return PrivateEcho(arg);
        }

        internal virtual void Do()
        {
            throw new NotImplementedException();
        }

        public int GetMyPrivateStaticProperty()
        {
            return PrivateStaticProperty;
        }
    }
}