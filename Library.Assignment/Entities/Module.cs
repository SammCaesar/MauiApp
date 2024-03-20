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
	}
}

