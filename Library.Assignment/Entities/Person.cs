using System;
namespace Library.Assignment1.Entities
{
	public class Person
	{
        public int ID { get; set; }
		public string Name { get; set; }
        public string Classification { get; set; }
        public List<int> Grades = new();
        public Person()
		{
		}

        public override string ToString()
        {
            return $"{Name} | {Classification}";
        }
    }
}

