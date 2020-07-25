using System.Collections.Generic;

namespace ProductManagement.QueryModel
{
    public class SpecificationQuery
    {
        public int LeafCategoryId { get; set; }
        public IEnumerable<SpecificationGroupQuery> Groups { get; set; }
    }

    public class SpecificationGroupQuery
    {
        public string Title { get; set; }
        public IEnumerable<SpecificationItemQuery> Items { get; set; }
    }

    public class SpecificationItemQuery
    {
        public string Title { get; set; }
        public int SpecificationItemValueType { get; set; }

        public IEnumerable<SpecificationItemOptionQuery> Options { set; get; }
    }

    public class SpecificationItemOptionQuery
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}