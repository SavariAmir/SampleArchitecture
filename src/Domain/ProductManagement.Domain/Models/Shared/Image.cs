using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Shared
{
    public class Image : ValueObject
    {
        public string Name { get; private set; }

        public Image(string name)
        {
            Name = name;
        }

        public static implicit operator Image(string input)
        {
            return new Image(input);
        }
    }
}