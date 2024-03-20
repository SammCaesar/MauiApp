﻿using System;
using Library.Assignment1.Services;
using Library.Assignment1.Entities;

namespace Assignment1.Helpers
{
	public class PersonHelper
	{
        private PersonService personSvc = PersonService.Current;
        private CourseService courseSvc = CourseService.Current;

        public void AddStudent()
        {
            string name, classification;
            Console.WriteLine("\nEnter the Student's Name: ");
            name = Console.ReadLine() ?? "";
            Console.WriteLine("\nEnter the Student's Grade/Year: ");
            classification = Console.ReadLine() ?? "";

            Person student = new Student { Name = name, Grade = classification, Classification = "Student" };

            personSvc.Add(student);
        }

        public void UpdateStudent()
        {
            int count = 0;
            Console.WriteLine("Choose number out of all courses: ");
            PersonService.Current.Students.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));

            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int intChoice))
            {
                var myPerson = PersonService.Current.Students.ElementAt(intChoice-1);

                Console.WriteLine("What is the new Name?");
                myPerson.Name = Console.ReadLine();

                Console.WriteLine("What is the Student's new Grade/Year");
                myPerson.Grade = Console.ReadLine();
            }
        }

        public void RemoveStudent()
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

        public Person FindPerson()
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

            return myPerson;
        }
        public Person FindStudent()
        {
            Console.WriteLine("\nPerson's Name you wish to search for: ");
            var name = Console.ReadLine();

            var myPerson = personSvc.SearchStudent(name).FirstOrDefault();

            if (myPerson != null)
            {
                Console.WriteLine("\nPerson Found: \n" + myPerson);
            }
            else
            {
                Console.WriteLine("\nNo Person Found!");
            }

            return myPerson;
        }

        public void StudentCourses()
        {
            ListPersons();

            Person myPerson = FindPerson();

            if (myPerson == null)
            {
                return;
            }

            bool nextFlag = false;

            List<Course> courses = courseSvc.Courses.ToList();

            Console.WriteLine("\n" + myPerson.Name + " courses are: ");

            foreach (Course c in courses)
            {
                if (c.Roster.Any<Person>(s => s == myPerson))
                {
                    nextFlag = true;
                    Console.WriteLine(c);
                }
            }

            if (!nextFlag)
            {
                Console.WriteLine("No Courses Found.");
            }

            return;
        }
    }
}

