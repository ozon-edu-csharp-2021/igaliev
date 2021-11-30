using System;

namespace MerchandiseService.Domain.Exceptions
{
    public class DomainOrderException : Exception
    {
        public DomainOrderException()
        { }

        public DomainOrderException(string message)
            : base(message)
        { }

        public DomainOrderException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}