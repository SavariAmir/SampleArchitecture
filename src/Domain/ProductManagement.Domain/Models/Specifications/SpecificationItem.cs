using Anshan.Framework.Domain;
using Anshan.Framework.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Domain.Models.Specifications
{
    public class SpecificationItem : Entity<int>
    {
        public string Title { get; private set; }
        public SpecificationItemValueType SpecificationItemValueType { get; private set; }
        public IReadOnlyCollection<SpecificationItemOption> SpecificationItemOptions => _specificationItemOptions;
        private readonly List<SpecificationItemOption> _specificationItemOptions = new List<SpecificationItemOption>();

        private SpecificationItem()
        {
        }

        public SpecificationItem(string title, SpecificationItemValueType specificationItemValueType, List<string> options)
        {
            Title = title;
            SpecificationItemValueType = specificationItemValueType;

            var isTypeSelect = specificationItemValueType == SpecificationItemValueType.MultiSelect ||
                               specificationItemValueType == SpecificationItemValueType.Select;

            if (!isTypeSelect) return;

            if (options != null && !options.Any()) throw new DomainException("");

            _specificationItemOptions = options.Select(p => new SpecificationItemOption(p)).ToList();
        }
    }
}