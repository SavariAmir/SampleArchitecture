using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Specifications
{
    public class SpecificationItemOption : Entity<int>
    {
        public string Value { get; private set; }

        private SpecificationItemOption()
        {
        }

        public SpecificationItemOption(string value)
        {
            Value = value;
        }

        public static implicit operator SpecificationItemOption(string input)
        {
            return new SpecificationItemOption(input);
        }
    }
}