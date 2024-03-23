using System;
using Library.Assignment1.Entities;
namespace Library.Assignment1.Services
{
	public class PersonService
	{
        private IList<Person> persons;

        private static object _lock = new object();
        private static PersonService? instance;
        public static PersonService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new PersonService();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Person> Persons
        {
            get
            {
                return persons ?? new List<Person>();
            }
        }
        public IEnumerable<Instructor> Instructors
        {
            get
            {
                return persons.Where(p => p is Instructor).Select(p => p as Instructor);
            }
        }
        public IEnumerable<Student> Students
        {
            get
            {
                return persons.Where(p => p is Student).Select(p => p as Student);
            }
        }

        private PersonService()
        {
            persons = new List<Person>();
            var sam = new Student()
            {
                Name = "Samuel Iturra",
                Classification = "Student",
                Grade = "Senior",
            };
            var Deac = new Student()
            {
                Name = "Deacon Palmer",
                Classification = "Student",
                Grade = "Junior",
            };
            var Jane = new Student()
            {
                Name = "Jane Doe",
                Classification = "Student",
                Grade = "Sophmore",
            };
            var Doug = new Student()
            {
                Name = "Doug Heffernan",
                Classification = "Student",
                Grade = "Freshman",
            };
            Add(sam);
            Add(Deac);
            Add(Jane);
            Add(Doug);
        }

        public IEnumerable<Person> Search(string query)
        {
            return Persons.Where(c =>
                c.Name.ToUpper().Contains(query.ToUpper()));
        }
        public IEnumerable<Instructor> SearchInstructor(string query)
        {
            return Instructors.Where(c =>
                c.Name.ToUpper().Contains(query.ToUpper()));
        }
        public IEnumerable<Student> SearchStudent(string query)
        {
            return Students.Where(c =>
                c.Name.ToUpper().Contains(query.ToUpper()));
        }

        public void Add(Person myPerson)
        {
            if (myPerson.ID == 0)
            {
                myPerson.ID = LastId + 1;
            }
            persons.Add(myPerson);
        }

        private int LastId
        {
            get
            {
                return Persons.Any() ? Persons.Select(p => p.ID).Max() : 0;
            }
        }

        public void Remove(Person myPerson)
        {
            persons.Remove(myPerson);
        }
    }
}

