using System;

namespace SampleCodeBase
{
    public static class Utility
    {
        public static void ThrowException()
        {
            throw new Exception("Hello");
        }

        public static void ThrowException(string message)
        {
            throw new Exception(message);
        }

        public static void ThrowException(Exception exception)
        {
            throw exception;
        }

        public static void ArgumentException(string message)
        {
            throw new ArgumentException(message);
        }

        public static void ArgumentNullException(string message)
        {
            throw new ArgumentNullException(message);
        }
    }
}