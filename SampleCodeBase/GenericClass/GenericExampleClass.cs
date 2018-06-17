using System;
using System.Collections.Generic;

namespace SampleCodeBase.GenericClass
{

    public interface IRequired<T1>
    {
        T1 T1Type { get; set; }
    }

    public interface IRequiredMethod
    {
        void ContainsRequiredMethod();
    }

    public interface IRequiredMethod2
    {
        void ContainsRequiredMethod2();
    }

    public interface IRequiredStringMethod3
    {
        string ContainsRequiredMethod3();
    }

    public class RequiredStringMethod3  : IRequiredStringMethod3
    {
        #region Implementation of IRequiredStringMethod3

        public string ContainsRequiredMethod3()
        {
            return "Sample Contains RequireMethod 3 " + DateTime.Now.Second;
        }

        #endregion
    }

    public class SampleTypeClass : IRequired<string>
    {
        public string SampleString { get; set; }

        #region Implementation of IRequired<string>

        public string T1Type { get; set; }

        #endregion
    }

    public class RequiredClass<T> : IRequired<RequiredClass<string>>
    {
        private string _toString;
        private string _xToString;
        private string _yToString;

        public RequiredClass(IRequired<T> required)
        {
            _toString = required.ToString();
        }

        public RequiredClass()
        {
        }

        public void TempMethod(T param1)
        {
            var x = "Hello World";
            var y = param1;

            Utility.ThrowException();

            _xToString = x.ToString();
            _yToString = y.ToString();

        }

        #region Implementation of IRequired<RequiredClass<string>>

        public RequiredClass<string> T1Type { get; set; }

        #endregion
    }

    public class RequiredClassParameterLess : IRequired<RequiredClass<RequiredClassParameterLess>>
    {
        private string _xToString;
        private string _yToString;

        public RequiredClassParameterLess()
        {
        }


        public void TempMethod(IRequired<RequiredClass<string>> param1)
        {
            var x = "Hello World";
            var y = param1;

            Utility.ThrowException();

            _xToString = x.ToString();
            _yToString = y.ToString();
        }

        #region Implementation of IRequired<RequiredClass<RequiredClassParameterLess>>

        public RequiredClass<RequiredClassParameterLess> T1Type { get; set; }

        #endregion
    }

    public class ComplexRequiredGenericClass<T1> where T1 : class, IRequired<T1>
    {
        private string _toString;
        private string _xToString;
        private string _yToString;
        private string _y2ToString;

        public ComplexRequiredGenericClass(IRequired<T1> required)
        {
            _toString = required.ToString();
        }

        public void ComplexMethod<T2>(T1 param1, T2 param2)
        {
            var x = "Hello World";
            var y1 = param1;
            var y2 = param2;

            Utility.ThrowException();

            _xToString = x.ToString();
            _yToString = y1.ToString();
            _y2ToString = y2.ToString();
        }
    }

    public class ComplexRequiredGenericClass2<T1>
    {
        private string _toString;
        private string _requiredToString;
        private ComplexRequiredGenericClass<RequiredClass<string>> _complexRequiredGenericClass;
        private string _xToString;
        private string _yToString;
        private object _y2ToString;

        public ComplexRequiredGenericClass2(IRequired<T1> required, IRequired<T1> required2, ComplexRequiredGenericClass<RequiredClass<string>> complexRequiredGenericClass)
        {
            _requiredToString = required.ToString();
            _complexRequiredGenericClass = complexRequiredGenericClass;
        }

        public void SimpleMethod(T1 param1)
        {
            var x = "Hello World";
            var y1 = param1;

            Utility.ThrowException();

            _xToString = x.ToString();
            _yToString = y1.ToString();
            _y2ToString = y1.ToString();

            Utility.ThrowException();
        }
    }

    /// <summary>
    /// Example of generic class.
    /// Participant needs to cover the whole class by 100% except for the if-else (if having problems)
    /// Things need to be dynamic.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public class GenericExampleClass<T1, T2, T3, T4> where T1 : new()
                                                     where T2 : class, IRequired<T1>
                                                     where T3 : struct
                                                     where T4 : ComplexRequiredGenericClass2<T2>
    {
        private T1 _t1;
        private string _y1ToSting;
        private string _y2ToSting;
        private string _y3ToSting;
        private string _y4ToSting;
        private string _xToString;
        private string _thisToString;
        private T1 _t1TypeToString;
        private T2 _t2;
        private T3 _t3;
        private Dictionary<int, T4> _dictionaryOfT4;
        private int _currentIndex;

        public GenericExampleClass()
        {
            _thisToString = this.ToString();
            ComplexNumber = GetComplexNumberInitialize();
            ComplexByteArray = GetComplexByteArrayInitialize((byte) (5 - 1));
            _dictionaryOfT4 = new Dictionary<int, T4>(100);
        }

        internal void Add(T4 item)
        {
            _dictionaryOfT4.Add(_currentIndex, item);
            _currentIndex++;
        }

        protected void Remove(T4 item)
        {
            if (_currentIndex <= 0)
            {
                return;
            }

            _dictionaryOfT4.Remove(_currentIndex);
            _currentIndex--;
        }

        internal void ComplexDictionaryItemPopulate(IDictionary<int, T4> dictionary, T4 item, T4 item2)
        {
            if (dictionary == null)
            {
                Utility.ArgumentNullException("dictionary");
            }

            foreach (var key in dictionary.Keys)
            {
                if (!_dictionaryOfT4.ContainsKey(key))
                {
                    Add(_dictionaryOfT4[key]);
                }
                else
                {
                    Add(item);
                    Add(item2);
                    Add(_dictionaryOfT4[key]);
                }
            }
        }

        public GenericExampleClass(int? example)
        {
            _thisToString = this.ToString();
            ComplexNumber = GetComplexNumberInitialize();

            if (example > 5)
            {
                ComplexByteArray = GetComplexByteArrayInitialize((byte) (example - 1));
            }
            else
            {
                if (example != null)
                {
                    ComplexByteArray = GetComplexByteArrayInitialize2((byte) example);
                }
            }
        }

        public int ComplexNumber { get; set; }

        private int GetComplexNumberInitialize() => 1 + DateTime.Now.Second + DateTime.Now.Second * 5;
        private int GetComplexNumberInitialize2() => 5 + DateTime.Now.Second + DateTime.Now.Second * 5;

        private byte[] GetComplexByteArrayInitialize(byte sample)
        {
            // never ever declare variable as 'x', it is not C# convention. it is VB convention.
            // C# convention is to write the full form.
            var r = new byte[5] { 1, sample, (byte) DateTime.Now.Second, 1, 0 };

            return r;
        }

        public byte[] GetComplexByteArrayInitialize2(byte sample)
        {
            // never ever declare variable as 'x', it is not C# convention. it is VB convention.
            // C# convention is to write the full form.
            var r = new byte[5] { 13, sample, (byte) DateTime.Now.Second, 1, 0 };

            return r;
        }

        public GenericExampleClass(T2 t2) : this(t2, default(T3))
        {
            ComplexNumber2 = GetComplexNumberInitialize2();
            ComplexByteArray = GetComplexByteArrayInitialize(2);
        }

        public byte[] ComplexByteArray { get; set; }

        public int ComplexNumber2 { get; set; }

        public GenericExampleClass(T2 t2, T3 t3)
        {
            _t1 = new T1();
            if (t2 != null)
            {
                _t2 = t2;
            }

            _t3 = t3;
        }

        public T1 CreateT1() => new T1();

        public T3 CreateT3() => (T3) Activator.CreateInstance(typeof(T3));

        public void SimpleTempMethod(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            // never ever declare variable as 'x', it is not C# convention. it is VB convention.
            // C# convention is to write the full form.
            var x = "Hello World";
            var y1 = t1;
            var y2 = t2;
            var y3 = t3;
            var y4 = t4;

            Utility.ThrowException();

            _y1ToSting = y1.ToString();
            _y2ToSting = y2.ToString();
            _y3ToSting = y3.ToString();
            _y4ToSting = y4.ToString();
            _xToString = x.ToString();
            _t1TypeToString = y2.T1Type;
            _thisToString = this.ToString();
        }

        public void TempMethodT5<T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) where T5 : IRequiredStringMethod3
        {
            var x = "Hello World";
            var y1 = t1;
            var y2 = t2;
            var y3 = t3;
            var y4 = t4;

            Utility.ThrowException();

            SimpleTempMethod(t1, t2, t3, t4);

            _y1ToSting = y1.ToString();
            _y2ToSting = y2.ToString();
            _y3ToSting = y3.ToString();
            _y4ToSting = y4.ToString();
            _thisToString = this.ToString();
            _xToString = x.ToString();

            Utility.ThrowException();
            SimpleTempMethod(t1, t2, t3, t4);
            SimpleTempMethod(t1, t2, t3, t4);
            SimpleTempMethod(t1, t2, t3, t4);
            SimpleTempMethod(t1, t2, t3, t4);
            SimpleTempMethod(t1, t2, t3, t4);

            t5.ContainsRequiredMethod3();
        }

        public void BusineLogicInvokeOfContainsRequiredMethod3()
        {
            var t5 = new RequiredStringMethod3();
            t5.ContainsRequiredMethod3();
        }
    }
}
