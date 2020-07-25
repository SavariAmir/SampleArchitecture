using Anshan.Framework.Domain;
using ProductManagement.Domain.Models.Shared;
using System.Collections.Generic;

namespace ProductManagement.Domain.Models.Brands
{
    public class Brand : AggregateRoot<int>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Image HeaderImage { get; private set; }
        public Image LogoImage { get; private set; }

        public IReadOnlyCollection<BrandCategory> BrandCategories => _brandCategories;
        private readonly List<BrandCategory> _brandCategories = new List<BrandCategory>();
    }
}