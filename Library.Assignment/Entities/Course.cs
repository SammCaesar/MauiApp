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

        //public override string ToString()
        //{
        //    return $"{Code} | {Name} \nDescription: {Description}";
        //}
        public override string ToString()
        {
            string result = $"{Code} | {Name} \nDescription: {Description}\nStudents:\n";
            foreach (var stud in Roster)
            {
                result += stud.ToString() + "\n";
            }
            result += "Modules:\n";
            foreach (var mod in Modules)
            {
                result += mod.ToString() + "\n";
            }
            result += "Assignments:\n";
            foreach (var ass in Assingments)
            {
                result += ass.ToString() + "\n";
            }
            return result;
        }
    }
}

