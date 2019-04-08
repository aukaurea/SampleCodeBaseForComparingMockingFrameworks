namespace SampleCodeBase.DelegateExamples
{
    public class NonVoidDelegate
    {
        public string GetNonDelegateExample(int a, int b)
        {
            var x = GetNonDelegateExample2(a, b);

            return x;
        }

        public string GetNonDelegateExample2(
                int a,
                int b) => (a + b).ToString();

        public int GetNonVoidDelegateExample2Main(int a, int b)
        {
            var x = GetNonVoidDelegateExample2Inner(a, b);

            return x;
        }

        public int GetNonVoidDelegateExample2Inner(int a, int b) => a + b;

        public int GetNonVoidDelegateExample3Main(
                int a,
                int b,
                int d)
        {
            var x = GetNonVoidDelegateExample3Inner(a, b, d);

            return x;
        }

        public int GetNonVoidDelegateExample3Inner(
                int a,
                int b,
                int d) =>
                a + b - d;

        public int GetNonVoidDelegateExample4Main(
                int a,
                int b,
                int d)
        {
            var x = GetNonVoidDelegateExample4Inner(a, b, d);

            return x;
        }

        public int GetNonVoidDelegateExample4Inner(
                int a,
                int b,
                int d) =>
                (short) (a + b - d);

        public string GetNonVoidDelegateExample5Main(
                int a,
                int b,
                int d)
        {
            var x = GetNonVoidDelegateExample5Inner(a, b, d);

            return x;
        }

        public string GetNonVoidDelegateExample5Inner(
                int a,
                int b,
                int d) =>
                (a + b - d == 3).ToString();

        public int GetNonVoidDelegateExample6ReturnMain(
                int a,
                int b,
                int d)
        {
            var x = GetNonVoidDelegateExample6ReturnInner(a, b, d);

            if (x > 5)
            {
                return GetNonVoidDelegateExample7ReturnInner(a, b, d);
            }

            return x;
        }

        public int GetNonVoidDelegateExample6ReturnInner(
                int a,
                int b,
                int d)
        {
            return a - b + d;
        }

        public int GetNonVoidDelegateExample7ReturnMain(
                int a,
                int b,
                int d)
        {
            var x = GetNonVoidDelegateExample7ReturnInner(a, b, d);

            return x;
        }

        public int GetNonVoidDelegateExample7ReturnInner(
                int a,
                int b,
                int d)
        {
            if (a > 5)
            {
                return a - b + d;
            }

            return a - b + d;
        }
    }
}