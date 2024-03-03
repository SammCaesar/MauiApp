using Assignment1.Entities;
using Assignment1.Services;
using Assignment1.Helpers;
namespace Assignment1;

internal class Program
{
    static void Main(string[] args)
    {
        var courseHelper = new CourseHelper();
        var personHelper = new PersonHelper();

        List<Person> studentList = new();
        List<Course> courseList = new();
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
                    AddToRoster(studentList, courseList);
                    break;
                case 4:
                    RemoveStudent(studentList, courseList);
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
                    StudentCourses(courseList, studentList);
                    break;
                case 10:
                    UpdateCourse(courseList);
                    break;
                case 11:
                    UpdateStudent(studentList);
                    break;
                case 12:
                    CreateAssignment(courseList);
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
    static void AddToRoster(List<Person> studentList, List<Course> courseList)
    {
        ListStudents(studentList);

        string name, classification;
        Console.WriteLine("\nWhich student would you like to add from the List of Students?");
        name = Console.ReadLine() ?? "";
        Console.WriteLine("\nWhat is the classification of that student?");
        classification = Console.ReadLine() ?? "";

        Person student = new Person();
        bool flag = false;

        foreach (Person s in studentList)
        {
            if(name == s.Name && classification == s.Classification)
            {
                student = s;
                flag = true;
            }
        }

        if (!flag)
        {
            Console.WriteLine("\nError: No Student Found!");
            return;
        }

        ListCourses(courseList);

        string code;
        do
        {
            Console.WriteLine("\nWhich Class would you like to add the student too? Please give the Course Code.");
            code = Console.ReadLine() ?? "";
        } while (code == "");

        bool secondFlag = false;
        foreach (Course c in courseList)
        {
            if(c.Code == code)
            {
                c.Roster.Add(student);
                secondFlag = true;
            }
        }
        if (!secondFlag)
        {
            Console.WriteLine("\nError: No Course Found!");
            return;
        }
    }
    static void RemoveStudent(List<Person> studentList, List<Course> courseList)
    {
        ListCourses(courseList);

        string code;
        do
        {
            Console.WriteLine("\nWhich Class would you like to remove the student from? Please give the Course Code.");
            code = Console.ReadLine() ?? "";
        } while (code == "");

        bool secondFlag = false;
        Course course = new();
        foreach (Course c in courseList)
        {
            if (c.Code == code)
            {
                course = c;
                secondFlag = true;
            }
        }
        if (!secondFlag)
        {
            Console.WriteLine("\nError: No Course Found!");
            return;
        }

        foreach (Person stud in course.Roster)
        {
            Console.WriteLine("\n"+stud);
        }

        string name, classification;
        do
        {
            Console.WriteLine("\nWhich student would you like to remove from the course's roster?");
            name = Console.ReadLine() ?? "";
            Console.WriteLine("\nWhat is the classification of that student?");
            classification = Console.ReadLine() ?? "";
        } while (name == "" || classification == "");

        int x = -1;

        for (int i = 0; i < course.Roster.Count(); i++)
        {
            if (name == course.Roster[i].Name && classification == course.Roster[i].Classification)
            {
                x = i;
            }
        }

        if (x == -1)
        {
            Console.WriteLine("\nError: No Student Found!");
            return;
        }

        course.Roster.RemoveAt(x);
    }
    static void ListCourses(List<Course> courseList)
    {
        Console.WriteLine("\nList of All Courses: ");
        foreach (Course course in courseList)
        {
            Console.WriteLine("Code: " + course.Code + " Name: " + course.Name);
        }

    }
    static void ListStudents(List<Person> studentList)
    {
        Console.WriteLine("\nList of all Students: ");
        int count = 0;
        PersonService.Current.Persons.ToList().ForEach(c => Console.WriteLine($"{++count}. {c}"));
    }
    static void StudentCourses(List<Course> courseList, List<Person> studentList)
    {
        ListStudents(studentList);
        string name, classification;
        do
        {
            Console.WriteLine("\nWhich student would you like to list their courses?");
            name = Console.ReadLine() ?? "";
            Console.WriteLine("\nWhat is the classification of that student?");
            classification = Console.ReadLine() ?? "";
        } while (name == "" || classification == "");

        Person student = new Person();
        bool flag = false;

        foreach (Person s in studentList)
        {
            if (name == s.Name && classification == s.Classification)
            {
                student = s;
                flag = true;
            }
        }

        if (!flag)
        {
            Console.WriteLine("\nError: No Student Found!");
            return;
        }

        bool nextFlag = false;
        Console.WriteLine("\n"+ student.Name + " courses are: ");
        foreach (Course c in courseList)
        {
            if(c.Roster.Any<Person>(s => s == student))
            {
                nextFlag = true;
                Console.WriteLine(c);
            }
        }

        if (!nextFlag)
        {
            Console.WriteLine("No Courses Found.");
        }
    }
    static void UpdateCourse(List<Course> courseList)
    {
        bool flag = false;
        ListCourses(courseList);
        string code;
        do
        {
            Console.WriteLine("\nWhich course would you like to update? Please give Course Code: ");
            code = Console.ReadLine() ?? "";
        } while (code == "");

        string newName, newDescription;
        foreach (Course c in courseList)
        {
            if (c.Code == code)
            {
                do
                {
                    Console.WriteLine("\nNew name for Course:");
                    newName = Console.ReadLine() ?? "";
                    Console.WriteLine("\nNew description for Course");
                    newDescription = Console.ReadLine() ?? "";
                } while (newName == "" || newDescription == "");

                c.Name = newName;
                c.Description = newDescription;
                flag = true;

                Console.WriteLine("Updated Course's Information");
            }
        }
        if (!flag)
        {
            Console.WriteLine("Error! Could not update Course's Information");
        }
    }
    static void UpdateStudent(List<Person> studentList)
    {
        bool flag = false;
        ListStudents(studentList);
        string name, classification;
        do
        {
            Console.WriteLine("\nWhich student would you like to update?");
            name = Console.ReadLine() ?? "";
            Console.WriteLine("\nWhat is the classification of that student?");
            classification = Console.ReadLine() ?? "";
        } while (name == "" || classification == "");

        string newName, newClassification;
        foreach (Person s in studentList)
        {
            if(s.Name == name && s.Classification == classification)
            {
                do
                {
                    Console.WriteLine("\nNew name for Student:");
                    newName = Console.ReadLine() ?? "";
                    Console.WriteLine("\nNew classification for student");
                    newClassification = Console.ReadLine() ?? "";
                } while (newName == "" || newClassification == "");

                s.Name = newName;
                s.Classification = newClassification;
                flag = true;

                Console.WriteLine("Updated Student's Information");
            }
        }
        if (!flag)
        {
            Console.WriteLine("Error! Could not update Student's Information");
        }
    }
    static void CreateAssignment(List<Course> courseList)
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

        ListCourses(courseList);
        string code;
        do
        {
            Console.WriteLine("\nWhich course would you like to update? Please give Course Code: ");
            code = Console.ReadLine() ?? "";
        } while (code == "");

        bool newFlag = false;
        foreach (Course c in courseList)
        {
            if (c.Code == code)
            {
                c.Assingments.Add(assignment);
                newFlag = true;
            }
        }

        if (!newFlag)
        {
            Console.WriteLine("Error! Could not add assingment to Course!");
        }
    }
}