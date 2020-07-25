using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Products
{
    public class ProductVideo : ValueObject
    {
        public string ProductVideoLink { get; private set; }

        private ProductVideo(string input)
        {
            ProductVideoLink = input;
        }

        private ProductVideo()
        {
        }

        public static implicit operator ProductVideo(string input)
        {
            return new ProductVideo(input);
        }
    }
}