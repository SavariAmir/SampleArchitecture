using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Reviews
{
    public class Rating : ValueObject
    {
        public int Rate { get; set; }
        public string UserId { get; set; }
    }
}