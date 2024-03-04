using System;
using Assignment1.Entities;
namespace Assignment1.Services
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

        private PersonService()
        {
            persons = new List<Person>();
        }

        public IEnumerable<Person> Search(string query)
        {
            return Persons.Where(c =>
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

