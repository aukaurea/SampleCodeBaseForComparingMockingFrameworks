using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SampleCodeBase.SimpleMultiClassExmaple
{
    public class SampleGeneric<T1, T2, T3>
    {
        private static T1 PrivateStaticT1Field;
        private T2 PrivateT2Field;
        private T3 PrivateT3Field;
        private List<T3> ListOfT3;
        private List<T2> ListOfT2;

        protected T1 ProtectedSampleMethod(string p1, string p2)
        {
            if (string.IsNullOrEmpty(p1))
            {
                // do stuff
            }

            try
            {

            }
            catch (ArgumentException e)
            {
                // do stuff
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }

            return default(T1);
        }

        protected T2 ProtectedSampleMethodT2(string p1, string p2)
        {
            if (string.IsNullOrEmpty(p1))
            {

            }

            return default(T2);
        }

        internal T2 InternalSampleMethodT2(string p1, string p2)
        {
            if (string.IsNullOrEmpty(p1))
            {

            }

            return default(T2);
        }

        private T2 PrivateSampleMethodT2(string p1, string p2)
        {
            if (string.IsNullOrEmpty(p1))
            {

            }

            return default(T2);
        }

        public T3 PublicSampleMethodT2(T2 p1, T1 p2)
        {
            if (p1 != null && p1.Equals(p2))
            {

            }

            return default(T3);
        }


        public T4 PublicSampleMethodT2<T4>(T2 p1, T1 p2)
        {
            if (p1 != null && p1.Equals(p2))
            {

            }

            return default(T4);
        }
    }

    public abstract class AbstractSampleClass
    {
        public abstract string PublicAbstractStringPropertyPrivateSet { get; set; }
    }

    public class SampleClass : AbstractSampleClass
    {
        private static string PrivateStaticStringField;
        private string PrivateStringField;
        private const string PrivateConstStringField = "";

        public string PublicStringProperty { get; set; }
        public string PublicStringPropertyPrivateGet { private get; set; }
        public string PublicStringPropertyPrivateSet { get; private set; }

        protected void ProtectedSampleMethod(string p1, string p2)
        {
            if (string.IsNullOrEmpty(p1))
            {
                // do stuff
                throw new Exception();
            }

            try
            {
                // do stuff
            }
            catch (ArgumentException e)
            {
                // do stuff
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }

        internal void InternalSampleMethod(string p1, string p2)
        {

        }

        #region Overrides of AbstractSampleClass

        public override string PublicAbstractStringPropertyPrivateSet { get; set; }

        #endregion
    }

    class InternalClass
    {
        public string InternalClassPublicStringProperty { get; set; }
        public string InternalClassPublicStringPropertyPrivateGet { private get; set; }
        public string InternalClassPublicStringPropertyPrivateSet { get; private set; }

        protected void ProtectedSampleMethod(string p1, string p2)
        {
            var x = "";
            var w = new SqlCommand();
            InternalClassPublicStringProperty = "";

            if (string.IsNullOrEmpty(p1))
            {
                // do stuff
                throw new Exception();
            }

            try
            {
                // do stuff
            }
            catch (ArgumentException e)
            {
                // do stuff
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }

        public class PublicInnerClassUnderInternalClass
        {
            public string PublicInnerClassUnderInternalClassPublicStringPropertyPrivateGet { private get; set; }
            public string PublicInnerClassUnderInternalClassPrivateStringPropertyPrivateSet { get; private set; }
        }
    }
}
