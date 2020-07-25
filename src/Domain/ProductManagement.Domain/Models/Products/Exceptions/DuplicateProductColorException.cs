using Anshan.Framework.Domain.Exceptions;

namespace ProductManagement.Domain.Models.Products.Exceptions
{
    public class DuplicateProductColorException : DomainException
    {
        public DuplicateProductColorException() : base("")
        {
        }
    }
}