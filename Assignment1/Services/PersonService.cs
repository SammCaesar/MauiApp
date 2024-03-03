using System;
using Assignment1.Entities;
namespace Assignment1.Services
{
	public class PersonService
	{
        private IList<Person> persons;

        private string? query;
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
                return persons.Where(
                    c =>
                        c.Name.ToUpper().Contains(query.ToUpper() ?? string.Empty));
            }
        }

        private PersonService()
        {
            persons = new List<Person>();
        }

        public IEnumerable<Person> Search(string query)
        {
            this.query = query;
            return Persons;
        }

        public void Add(Person myPerson)
        {
            persons.Add(myPerson);
        }

        public void Remove(Person myPerson)
        {
            persons.Remove(myPerson);
        }
    }
}

