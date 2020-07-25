using System;

namespace Anshan.Framework.Security
{
    public class UnauthorizedException : Exception
    {
        public string Code { get; private set; }

        public UnauthorizedException(string code, string message) : base(message)
        {
            this.Code = code;
        }
    }
}