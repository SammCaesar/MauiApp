using System;
using Assignment1.Services;
using Assignment1.Entities;
namespace Assignment1.Helpers
{
	public class PersonHelper
	{
        private PersonService personSvc = PersonService.Current;

        public void AddPerson()
        {
            string name, classification;
            Console.WriteLine("\nEnter the Student's Name: ");
            name = Console.ReadLine() ?? "";
            Console.WriteLine("\nEnter the Student's Classification: ");
            classification = Console.ReadLine() ?? "";

            Person student = new Person { Name = name, Classification = classification };

            personSvc.Add(student);
        }

        public void UpdatePerson()
        {
            int count = 0;
            Console.WriteLine("Choose number out of all courses: ");
            PersonService.Current.Persons.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));

            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int intChoice))
            {
                var myPerson = PersonService.Current.Persons.ElementAt(intChoice-1);

                Console.WriteLine("What is the new Name?");
                myPerson.Name = Console.ReadLine();

                Console.WriteLine("What is the new Classification?");
                myPerson.Classification = Console.ReadLine();
            }
        }

        public void RemovePerson()
        {
            int count = 0;
            PersonService.Current.Persons.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));

            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int intChoice))
            {
                var myPerson = PersonService.Current.Persons.ElementAt(intChoice);

                personSvc.Remove(myPerson);
            }
        }

        public void ListPersons()
        {
            Console.WriteLine("\nList of All Persons: ");

            personSvc.Persons.ToList().ForEach(Console.WriteLine);
        }

        public  void FindPerson()
        {
            Console.WriteLine("\nPerson's Name you wish to search for: ");
            var name = Console.ReadLine();

            var myPerson = personSvc.Search(name).FirstOrDefault();

            if (myPerson != null)
            {
                Console.WriteLine("\nPerson Found: \n" + myPerson);
            }
            else
            {
                Console.WriteLine("\nNo Person Found!");
            }
        }
    }
}

