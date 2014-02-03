using System;

namespace MyUnit.CustomAttributes
{
    public class TestFixture:System.Attribute
    {

    }

    public class Test : System.Attribute
    {

    }

    public static class Assert
    {
        public static void IsFail(string message)
        {           
            throw new AssertException(message);
           
        }
    }

    public class AssertException : Exception
    {
        public AssertException(string message)
        : base(message) { }

    }
}
