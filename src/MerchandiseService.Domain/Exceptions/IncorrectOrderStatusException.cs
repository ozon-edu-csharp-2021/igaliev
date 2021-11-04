using System;

 namespace MerchandiseService.Domain.Exceptions
{
    public class IncorrectOrderStatusException : Exception
    {
        public IncorrectOrderStatusException(string message) : base(message)
        {
            
        }
        
        public IncorrectOrderStatusException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}