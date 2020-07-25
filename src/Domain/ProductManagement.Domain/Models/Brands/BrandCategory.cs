using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Brands
{
    public class BrandCategory : ValueObject
    {
        public int SubCategoryId { get; set; }
    }
}