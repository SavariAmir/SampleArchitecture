using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Dimensions
{
    public class DimensionItem : Entity<int>
    {
        public string Title { get; private set; }
        public UnitOfMeasurementType UnitOfMeasurementType { get; private set; }

        public DimensionItem(string title, UnitOfMeasurementType unitOfMeasurementType)
        {
            Title = title;
            UnitOfMeasurementType = unitOfMeasurementType;
        }

        private DimensionItem()
        {
        }
    }
}