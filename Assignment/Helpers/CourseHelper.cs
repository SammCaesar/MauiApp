using System;
using Library.Assignment1.Services;
using Library.Assignment1.Entities;
using System.Xml.Linq;

namespace Assignment1.Helpers
{
	public class CourseHelper
	{
		private CourseService courseSvc = CourseService.Current;
        private PersonHelper personHelper = new PersonHelper();

        public void AddCourse()
		{
            string name, code, description;

            Console.WriteLine("\nEnter the Course's Code: ");
            code = Console.ReadLine() ?? "";
            Console.WriteLine("\nEnter the Course's Name: ");
            name = Console.ReadLine() ?? "";
            Console.WriteLine("\nEnter the Course's Description: ");
            description = Console.ReadLine() ?? "";

            Course myCourse = new Course { Code = code, Name = name, Description = description };

            courseSvc.Add(myCourse);
        }

        public void UpdateCourse()
        {
            int count = 0;
            Console.WriteLine("Choose number out of all courses: ");
            CourseService.Current.Courses.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));

            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int intChoice))
            {
                Course myCourse = CourseService.Current.Courses.ElementAt(intChoice-1);

                Console.WriteLine("What is the new Name?");
                myCourse.Name = Console.ReadLine();

                Console.WriteLine("What is the new Description?");
                myCourse.Description = Console.ReadLine();
            }
        }

        public void RemoveCourse()
        {
            int count = 0;
            CourseService.Current.Courses.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));

            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int intChoice))
            {
                Course myCourse = CourseService.Current.Courses.ElementAt(intChoice);

                courseSvc.Remove(myCourse);
            }
        }

        public void ListCourses()
        {
            Console.WriteLine("\nList of All Courses: ");

            courseSvc.Courses.ToList().ForEach(Console.WriteLine);
        }

        public Course FindCourse()
        {
            Course? myCourse;

            Console.WriteLine("\nSearch for Course: ");
            var input = Console.ReadLine();

            myCourse = courseSvc.Search(input).FirstOrDefault();

            if (myCourse != null)
            {
                Console.WriteLine("\nCourse Found: \n" + myCourse);
            }
            else
            {
                Console.WriteLine("\nNo Course Found!");
            }

            return myCourse;
        }

        public void AddToRoster()
        {
            personHelper.ListPersons();

            Person myPerson = personHelper.FindPerson();

            if (myPerson == null)
            {
                return;
            }

            ListCourses();

            Course myCourse = FindCourse();

            if (myCourse == null)
            {
                return;
            }

            myCourse.Roster.Add(myPerson);

            Console.WriteLine(myPerson.Name + " added to " + myCourse.Name + ".");

            return;
        }

        public void RemoveFromRoster()
        {
            ListCourses();

            Course myCourse = FindCourse();

            if (myCourse == null)
            {
                return;
            }

            foreach (Person stud in myCourse.Roster)
            {
                Console.WriteLine("\n" + stud);
            }

            Console.WriteLine("\nWhich student would you like to remove from the course's roster?");
            var name = Console.ReadLine();

            int x = -1;

            for (int i = 0; i < myCourse.Roster.Count(); i++)
            {
                if (name == myCourse.Roster[i].Name)
                {
                    x = i;
                }
            }

            if (x == -1)
            {
                Console.WriteLine("\nError: No Student Found!");
                return;
            }

            myCourse.Roster.RemoveAt(x);

            Console.WriteLine(name + " removed from " + myCourse.Name + ".");

            return;
        }

        public void CreateAssignment()
        {
            bool flag = false;
            string name, description, dueDate, totalAvailablePoints;
            DateTime dateDue;
            int totalAPInt;
            Assignment assignment = new();
            do
            {
                Console.WriteLine("Enter a name for the assignment: ");
                name = Console.ReadLine() ?? "";
                Console.WriteLine("Enter a description for the assignment: ");
                description = Console.ReadLine() ?? "";
                Console.WriteLine("Enter the total available points for the assignment: ");
                totalAvailablePoints = Console.ReadLine() ?? "";
                Console.WriteLine("Enter the due date for the assingment (dd/MM/yyyy): ");
                dueDate = Console.ReadLine() ?? "";

                try
                {
                    totalAPInt = Convert.ToInt32(totalAvailablePoints);
                    dateDue = DateTime.Parse(dueDate);

                    assignment.Name = name;
                    assignment.Description = description;
                    assignment.TotalAvailablePoints = totalAPInt;
                    assignment.DueDate = dateDue;

                    flag = true;
                }
                catch
                {
                    flag = false;
                }
            } while (!flag);

            ListCourses();

            Course myCourse = FindCourse();

            if (myCourse == null)
            {
                return;
            }

            myCourse.Assingments.Add(assignment);

            Console.WriteLine("Added assignment to Course.");

            return;
        }
    }
}

