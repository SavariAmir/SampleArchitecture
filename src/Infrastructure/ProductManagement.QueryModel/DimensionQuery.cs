using System.Collections.Generic;

namespace ProductManagement.QueryModel
{
    public class DimensionQuery
    {
        public int LeafCategoryId { get; set; }
        public IEnumerable<DimensionGroupQuery> Groups { get; set; }
    }

    public class DimensionGroupQuery
    {
        public string Title { get; set; }
        public IEnumerable<DimensionItemQuery> Items { get; set; }
    }

    public class DimensionItemQuery
    {
        public string Title { get; set; }
        public int UnitOfMeasurementType { get; set; }
    }
}