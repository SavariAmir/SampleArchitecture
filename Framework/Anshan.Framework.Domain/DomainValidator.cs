using Anshan.Framework.Domain.Specification.Common;

namespace Anshan.Framework.Domain
{
    public abstract class DomainValidator : IDomainValidator
    {
        protected readonly NotNullOrEmptySpecification NotNullOrEmptySpec;
        protected readonly NumberRangeSpecification OneOrGreaterSpec;
        protected readonly NumberPrecisionSpecification NumberPrecisionSpec;
        protected readonly PhoneNumberSpecification PhoneNumberSpec;

        protected DomainValidator()
        {
            NotNullOrEmptySpec = new NotNullOrEmptySpecification();
            OneOrGreaterSpec = new NumberRangeSpecification(1, int.MaxValue);
            NumberPrecisionSpec = new NumberPrecisionSpecification(18, 16);
            PhoneNumberSpec = new PhoneNumberSpecification();
        }

        public abstract bool IsValid { get; }
    }
}