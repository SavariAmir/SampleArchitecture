using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Questions
{
    public class ProductQuestion : AggregateRoot<int>
    {
        public int ProductId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int HelpfulCount { get; set; }
        public string UserFullName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}