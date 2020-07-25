using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Products
{
    public class ProductOverview : ValueObject
    {
        public string AtAGlance { get; private set; }
        public string Description { get; private set; }

        public ProductOverview(string atAGlance, string description)
        {
            AtAGlance = atAGlance;
            Description = description;
        }
    }
}