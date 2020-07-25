using Anshan.Framework.Domain.Exceptions;

namespace ProductManagement.Domain.Models.Products.Exceptions
{
    public class MoneyCannotBeANegativeValueException : DomainException
    {
        public MoneyCannotBeANegativeValueException() : base("Validation failed")
        {
        }
    }
}