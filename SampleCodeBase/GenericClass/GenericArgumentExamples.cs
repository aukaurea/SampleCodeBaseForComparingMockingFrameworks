using System.Collections.Generic;

namespace SampleCodeBase.GenericClass
{
    public interface IGenericArgumentExample1<T1, T2>
    {
        string S1 { get; set; }

        string S2 { get; set; }

        T1 T1x { get; set; }

        T2 T2x { get; set; }
    }

    class GenericArgumentExample1 : IGenericArgumentExample1<string, int>
    {
        #region Implementation of IGenericArgumentExample1<string,int>

        /// <inheritdoc />
        public string S1 { get; set; }

        /// <inheritdoc />
        public string S2 { get; set; }

        /// <inheritdoc />
        public string T1x { get; set; }

        /// <inheritdoc />
        public int T2x { get; set; }

        #endregion
    }

    public interface Ix2<T1, T2>
    {
        string S1 { get; set; }

        string S2 { get; set; }

        T1 T1x { get; set; }

        T2 T2x { get; set; }
    }

    public interface Ix3<T1, T2>
    {
        string S1 { get; set; }

        string S2 { get; set; }

        T1 T1x { get; set; }

        T2 T2x { get; set; }
    }

    class X3 : Ix3<IList<string>, int>
    {
        #region Implementation of Ix3<IList<string>,int>

        /// <inheritdoc />
        public string S1 { get; set; }

        /// <inheritdoc />
        public string S2 { get; set; }

        /// <inheritdoc />
        public IList<string> T1x { get; set; }

        /// <inheritdoc />
        public int T2x { get; set; }

        #endregion
    }

    public class GenericArgumentExamples<IGenericArgumentExample1>
    {
        public T MethodWithComplexParameters<T, T3>(
                IGenericArgumentExample1<string, int> sampleParameter,
                IGenericArgumentExample1<long, int> sampleParameter2,
                string[,,,] tGeneric4,
                int?[,,] nullableInt,
                int? questionMark,
                string[] hello5,
                IList<string> hello,
                Ix2<string, long>[,,] xt5,
                Ix3<IList<string>, int>[,,,,] xt6)
        {
            var hello3 = hello;
            var hello2 = hello3;

            // do nothing.
            //MethodWithComplexParameters2(
            //        new GenericArgumentExample1(),
            //        sampleParameter2,
            //        new string[2, 1, 2, 2],
            //        5,
            //        ((string)("Hello " + 1)).ToString(),
            //        new string[1] { "" },
            //        hello2,
            //        xt5,
            //        xt6);

            return default(T);
        }

        //public void MethodWithComplexParameters2(
        //        IGenericArgumentExample1<string, int> sampleParameter1,
        //        IGenericArgumentExample1<long, int> sampleParameter2,
        //        string[,,,] tGeneric4,
        //        int? questionMark,
        //        string questionMark2,
        //        string[] hello5,
        //        IList<string> hello,
        //        Ix2<string, long>[,,] xt5,
        //        Ix3<IList<string>, int>[,,,,] xt6)
        //{
        //    // do nothing.
        //}
    }
}