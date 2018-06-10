using System;
using System.Collections.Generic;

namespace SampleCodeBase.JustMockExamples
{
    public partial class Foo : IFoo
    {
        static Foo()
        {
            throw new NotImplementedException();
        }

        public static void Submit()
        {
        }

        public static int FooProp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Foo()
        {
        }
        public int Execute(int arg1, int arg2)
        {
            throw new NotImplementedException();
        }
        public delegate void EchoEventHandler(bool echoed);
        public event EchoEventHandler OnEchoCallback;

        public List<object> RealCollection
        {
            get { return collection; }
        }
        private List<object> collection;

        public IList<object> FakeCollection()
        {
            List<object> resultCollection = new List<object>();

            resultCollection.Add("asd");
            resultCollection.Add(123);
            resultCollection.Add(true);

            return resultCollection;
        }

        internal virtual string Value
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        private static int PrivateStaticProperty { get; set; }

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

        public void Execute()
        { }

        public void Execute(int arg)
        {
            DoPrivate(arg);
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