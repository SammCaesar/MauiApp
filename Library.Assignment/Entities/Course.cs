using System;
namespace Library.Assignment1.Entities
{
	public class Course
	{
        public int ID { get; set; }
		public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Person> Roster = new();
        public List<Assignment> Assingments = new();
        public List<Module> Modules = new();
        public Course()
		{
		}

        public override string ToString()
        {
            return $"{Code} | {Name} \nDescription: {Description}";
        }
    }
}

