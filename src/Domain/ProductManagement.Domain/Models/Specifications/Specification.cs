using Anshan.Framework.Domain;
using System.Collections.Generic;

namespace ProductManagement.Domain.Models.Specifications
{
    public class Specification : AggregateRoot<int>
    {
        public int LeafCategoryId { get; private set; }

        public IReadOnlyCollection<SpecificationGroup> SpecificationGroups => _specificationGroups;
        private readonly List<SpecificationGroup> _specificationGroups = new List<SpecificationGroup>();

        private Specification()
        {
        }

        public Specification(int leafCategoryId)
        {
            LeafCategoryId = leafCategoryId;
        }

        public Specification(int leafCategoryId, IEnumerable<SpecificationGroup> specificationGroups)
        {
            LeafCategoryId = leafCategoryId;
            _specificationGroups.AddRange(specificationGroups);
        }

        public void AddSpecificationGroup(string title)
        {
            var dimensionGroup = new SpecificationGroup(title);
            _specificationGroups.Add(dimensionGroup);
        }
    }
}