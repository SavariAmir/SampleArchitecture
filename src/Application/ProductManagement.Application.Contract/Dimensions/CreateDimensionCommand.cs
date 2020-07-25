using System.Collections.Generic;

namespace ProductManagement.Application.Contract.Dimensions
{
    public class CreateDimensionCommand
    {
        public int LeafCategoryId { get; set; }
        public IEnumerable<DimensionGroupCommand> Groups { get; set; }
    }

    public class DimensionGroupCommand
    {
        public string Title { get; set; }
        public IEnumerable<DimensionItemCommand> Items { get; set; }
    }

    public class DimensionItemCommand
    {
        public string Title { get; set; }
        public int UnitOfMeasurementType { get; set; }
    }
}