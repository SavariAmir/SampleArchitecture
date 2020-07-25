using Anshan.Framework.Domain;
using System.Collections.Generic;

namespace ProductManagement.Domain.Models.Specifications
{
    public class SpecificationGroup : Entity<int>
    {
        public string Title { get; private set; }

        public IReadOnlyCollection<SpecificationItem> SpecificationItems => _specificationItems;
        private readonly List<SpecificationItem> _specificationItems = new List<SpecificationItem>();

        private SpecificationGroup()
        {
        }

        public SpecificationGroup(string title)
        {
            Title = title;
        }

        public void AddSpecificationItem(IEnumerable<SpecificationItem> items)
        {
            _specificationItems.AddRange(items);
        }
    }
}