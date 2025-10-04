namespace Task2 
{ 

    public class NegativeNumberException : Exception
    {
        
        public NegativeNumberException() : base("Введено отрицательное число.")
        {
        }
        
        public NegativeNumberException(string message) : base(message)
        {
        }

        public NegativeNumberException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
