namespace RestaurantAPI
{
    public class NullException : Exception
    {
        public NullException()
            : base() { }

        public NullException(string message)
            : base(message) { }

        public NullException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
