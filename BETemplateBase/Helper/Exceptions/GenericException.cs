using System;

namespace Helper.Exceptions
{
    public class GenericException : Exception
    {
        public GenericException(string message) : base(message) { }
    }
}
