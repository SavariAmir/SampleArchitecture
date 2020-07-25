using Anshan.Framework.Domain;
using System.Collections.Generic;

namespace ProductManagement.Domain.Models.Dimensions
{
    public class Dimension : AggregateRoot<int>
    {
        public int LeafCategoryId { get; private set; }
        public IReadOnlyCollection<DimensionGroup> DimensionGroups => _dimensionGroups;
        private readonly List<DimensionGroup> _dimensionGroups = new List<DimensionGroup>();

        public Dimension(int leafCategoryId, IEnumerable<DimensionGroup> dimensionGroups)
        {
            LeafCategoryId = leafCategoryId;
            _dimensionGroups.AddRange(dimensionGroups);
        }

        private Dimension()
        {
        }
    }
}