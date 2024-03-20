using System;
namespace Library.Assignment1.Entities
{
	public class Person
	{
        public int ID { get; set; }
		public string Name { get; set; }
        public string Classification { get; set; } // Student or Instructor
        
        public Person()
		{
		}

        public override string ToString()
        {
            return $"[{ID}] {Name} | {Classification}";
        }
    }
}

