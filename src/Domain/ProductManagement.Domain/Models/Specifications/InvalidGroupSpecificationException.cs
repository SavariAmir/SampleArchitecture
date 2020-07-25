using Anshan.Framework.Domain.Exceptions;

namespace ProductManagement.Domain.Models.Specifications
{
    public class InvalidGroupSpecificationException : DomainException
    {
        public InvalidGroupSpecificationException() : base("")
        {
        }
    }
}