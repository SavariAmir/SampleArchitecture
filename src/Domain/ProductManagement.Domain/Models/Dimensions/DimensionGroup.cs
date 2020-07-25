using Anshan.Framework.Domain;
using System.Collections.Generic;

namespace ProductManagement.Domain.Models.Dimensions
{
    public class DimensionGroup : Entity<int>
    {
        public string Title { get; private set; }

        public IReadOnlyCollection<DimensionItem> DimensionItems => _dimensionItems;
        private readonly List<DimensionItem> _dimensionItems = new List<DimensionItem>();

        private DimensionGroup()
        {
        }

        public DimensionGroup(string title)
        {
            Title = title;
        }

        public void AddDimensionItem(IEnumerable<DimensionItem> items)
        {
            _dimensionItems.AddRange(items);
        }
    }
}