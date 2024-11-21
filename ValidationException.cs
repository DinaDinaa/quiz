namespace QwizzPlatform
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
        public ValidationException() { }    
    }
}
