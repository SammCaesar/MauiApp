using Library.Assignment1.Entities;
using Library.Assignment1.Services;
using Assignment1.Helpers;
namespace Assignment1;

internal class Program
{
    static void Main(string[] args)
    {
        var courseHelper = new CourseHelper();
        var personHelper = new PersonHelper();

        bool exit = false;

        while (!exit)
        {
            int input = ViewMenu();
            switch (input)
            {
                case 0:
                    Console.WriteLine("\nError you entered invalid input! Try Again!");
                    break;
                case 1:
                    courseHelper.AddCourse();
                    break;
                case 2:
                    personHelper.AddPerson();
                    break;
                case 3:
                    courseHelper.AddToRoster();
                    break;
                case 4:
                    courseHelper.RemoveFromRoster();
                    break;
                case 5:
                    courseHelper.ListCourses();
                    break;
                case 6:
                    courseHelper.FindCourse();
                    break;
                case 7:
                    personHelper.ListPersons();
                    break;
                case 8:
                    personHelper.FindPerson();
                    break;
                case 9:
                    personHelper.StudentCourses();
                    break;
                case 10:
                    courseHelper.UpdateCourse();
                    break;
                case 11:
                    personHelper.UpdatePerson();
                    break;
                case 12:
                    courseHelper.CreateAssignment();
                    break;
                case 13:
                    exit = true;
                    break;
            }
        }
    }
    static int ViewMenu()
    {
        try
        {
            Console.Write("\n1. Create a course and add it to a list of courses." +
            "\n2. Create a student and add it to a list of students." +
            "\n3. Add a student from the list of students to a specific course." +
            "\n4. Remove a student from a course's roster." +
            "\n5. List all courses." +
            "\n6. Search for courses by name or description" +
            "\n7. List all students." +
            "\n8. Search for a student by name." +
            "\n9. List all courses a student is taking." +
            "\n10. Update a course's information." +
            "\n11. Update a student's information." +
            "\n12. Create an assignment and add it to the list of assignments for a course." +
            "\n13. Exit Program." +
            "\nEnter the corresponding number to the action you wish to do: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            return 0;
        }
        
    }
}