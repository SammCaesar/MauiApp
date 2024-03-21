using System;
namespace Library.Assignment1.Entities
{
	public class Module
	{
        public string Name { get; set; }
        public string Description { get; set; }
		public List<ContentItem> Content = new();
        public Module()
		{
		}
        public override string ToString()
        {
            string result = $"Module: {Name}\nDescription: {Description}\n";
            foreach (var item in Content)
            {
                result += item.ToString() + "\n";
            }
            return result;
        }
    }
}

