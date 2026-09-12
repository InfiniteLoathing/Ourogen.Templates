using System;

namespace Ourogen.Templates.Exceptions
{
    internal class InvalidTemplateException : Exception
    {
        public InvalidTemplateException(string message) : base(message)
        {
            
        }
    }
}