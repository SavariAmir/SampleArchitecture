using Anshan.Framework.Domain;
using Anshan.Framework.Domain.Exceptions;

namespace ProductManagement.Domain.Models.Products
{
    public class ProductPrice : ValueObject
    {
        public Money Amount { get; private set; }
        public Money DiscountAmount { get; private set; }
        public Money DueAmount { get; private set; }
        public int DiscountPercent { get; private set; }

        private ProductPrice()
        {
        }

        public ProductPrice(decimal amount, int discountPercent)
        {
            ThrowExceptionIfDiscountPercentIsNotValid(discountPercent);

            Amount = amount;
            DiscountPercent = discountPercent;

            CalculatePrices();
        }

        private static void ThrowExceptionIfDiscountPercentIsNotValid(int discountPercent)
        {
            if (discountPercent < 0 || discountPercent > 100)
                throw new DiscountPercentInvalidException();
        }

        private void CalculatePrices()
        {
            DiscountAmount = Amount * DiscountPercent / 100;
            DueAmount = Amount - DiscountAmount;
        }
    }

    public class DiscountPercentInvalidException : DomainException
    {
        public DiscountPercentInvalidException() : base("Validation failed")
        {
        }
    }
}