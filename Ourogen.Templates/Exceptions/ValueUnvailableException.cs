namespace Ourogen.Templates.Exceptions
{
    internal class ValueUnavailableException : InvalidTemplateException
    {
        public ValueUnavailableException(string message) : base("Value Unavailable: " + message)
        {
            
        }
    }
}