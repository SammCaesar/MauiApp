using System;
namespace Library.Assignment1.Entities
{
	public class ContentItem
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public ContentItem()
		{
		}
        public override string ToString()
        {
            return $"Content: {Name} Description: {Description}";
        }
    }
}

