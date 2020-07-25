using System.Collections.Generic;

namespace ProductManagement.Application.Contract.Specifications
{
    public class CreateSpecificationCommand
    {
        public int LeafCategoryId { get; set; }
        public IEnumerable<SpecificationGroupCommand> Groups { get; set; }
    }

    public class SpecificationGroupCommand
    {
        public string Title { get; set; }
        public IEnumerable<SpecificationItemCommand> Items { get; set; }
    }

    public class SpecificationItemCommand
    {
        public string Title { get; set; }
        public int SpecificationItemValueType { get; set; }

        public List<string> Options { get; set; }
    }
}