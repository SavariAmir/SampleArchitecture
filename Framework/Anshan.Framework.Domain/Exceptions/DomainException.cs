using System;

namespace Anshan.Framework.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public string Code { get; private set; }

        public DomainException(string code, string message) : base(message)
        {
            this.Code = code;
        }

        public DomainException(string message) : base(message)
        {
        }
    }
}