using Anshan.Framework.Domain;
using ProductManagement.Domain.Models.Shared;
using System.Collections.Generic;

namespace ProductManagement.Domain.Models.Reviews
{
    public class Review : AggregateRoot<int>
    {
        public int ProductId { get; set; }
        public Rating Rating { get; set; }

        public string Description { get; set; }
        public int HelpfulCount { get; set; }
        public IReadOnlyCollection<Image> Images => _images;
        private readonly List<Image> _images = new List<Image>();
    }
}