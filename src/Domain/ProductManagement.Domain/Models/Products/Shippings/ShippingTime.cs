using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Products.Shippings
{
    public class ShippingTime : ValueObject
    {
        public ShippingTime(ShippingTimeType shippingTimeType, int quantity)
        {
            ShippingTimeType = shippingTimeType;
            Quantity = quantity;
        }

        public ShippingTimeType ShippingTimeType { get; private set; }
        public int Quantity { get; private set; }
    }
}