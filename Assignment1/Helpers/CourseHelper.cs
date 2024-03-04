using System;
using Assignment1.Services;
using Assignment1.Entities;
using System.Xml.Linq;

namespace Assignment1.Helpers
{
	public class CourseHelper
	{
		private CourseService courseSvc = CourseService.Current;

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

        public void FindCourse()
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
        }
    }
}

