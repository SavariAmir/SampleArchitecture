using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Products.Shippings
{
    public class Shipping : ValueObject
    {
        public Shipping(ShippingAmountType shippingAmountType, decimal shippingAmount, ShippingTimeType shippingTimeType, int quantity)
        {
            ShippingAmountType = shippingAmountType;
            ShippingAmount = shippingAmount;
            ShippingTime = new ShippingTime(shippingTimeType, quantity);
        }

        public Shipping()
        {
        }

        public ShippingAmountType ShippingAmountType { get; private set; }
        public Money ShippingAmount { get; private set; }
        public ShippingTime ShippingTime { get; private set; }
    }
}