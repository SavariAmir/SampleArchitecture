using Anshan.Framework.Domain;
using ProductManagement.Domain.Models.Products.Exceptions;

namespace ProductManagement.Domain.Models.Products
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }

        private Money(decimal value)
        {
            ThrowExceptionIfNotValid(value);
            Value = value;
        }

        public static implicit operator Money(decimal value)
        {
            return new Money(value);
        }

        public static Money operator -(Money left, Money right)
        {
            var finalValue = left.Value - right.Value;
            return new Money(finalValue);
        }

        public static Money operator *(Money left, int right)
        {
            var finalValue = left.Value * right;
            return new Money(finalValue);
        }

        public static Money operator /(Money left, int right)
        {
            var finalValue = left.Value / right;
            return new Money(finalValue);
        }

        private static void ThrowExceptionIfNotValid(decimal value)
        {
            if (value < 0)
                throw new MoneyCannotBeANegativeValueException();
        }
    }
}