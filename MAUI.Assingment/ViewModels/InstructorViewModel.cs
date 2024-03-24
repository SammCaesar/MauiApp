using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.Assignment1.Entities;
using Library.Assignment1.Services;

namespace MAUI.Assingment.ViewModels
{
    public class InstructorViewModel : INotifyPropertyChanged
    {
        private PersonService personSvc;
        private CourseService courseSvc;
        private Course? course;
        public string Query { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Code
        {
            get { return course?.Code ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Code = value;
            }
        }
        public string Name
        {
            get { return course?.Name ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Name = value;
            }
        }
        public string Description
        {
            get { return course?.Description ?? string.Empty; }
            set
            {
                if (course == null) course = new Course();
                course.Description = value;
            }
        }
        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(courseSvc.Courses);
            }
        }
        [Obsolete]
        public ObservableCollection<string> DetailedCourses
        {
            get
            {
                return new ObservableCollection<string>(courseSvc.DetailedCourses);
            }
        }
        public ObservableCollection<Person> Persons
        {
            get
            {
                return new ObservableCollection<Person>(personSvc.Persons);
            }
        }
        public ObservableCollection<Instructor> Instructors
        {
            get
            {
                return new ObservableCollection<Instructor>(personSvc.Instructors);
            }
        }
        public ObservableCollection<Student> Students
        {
            get
            {
                return new ObservableCollection<Student>(personSvc.Students
                    .ToList().Where(c => c?.Name?.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }
        public Person SelectedPerson
        {
            get; set;
        }
        public Course SelectedCourse
        {
            get; set;
        }
        public InstructorViewModel()
        {
            personSvc = PersonService.Current;
            courseSvc = CourseService.Current;
            course = new Course();
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Persons));
            NotifyPropertyChanged(nameof(Students));
            NotifyPropertyChanged(nameof(Courses));
            NotifyPropertyChanged(nameof(DetailedCourses));
        }
        [Obsolete]
        public void AddStudent()
        {
            Student myStudent = new Student()
            {
                Name = "Test Student",
                Classification = "Student",
                Grade = "Senior",
            };

            personSvc.Add(myStudent);
            NotifyPropertyChanged("Students");
        }
        public void DeleteStudent()
        {
            personSvc.Remove(SelectedPerson);
            RefreshView();
        }
        public void EnrollStudent()
        {
            if (SelectedPerson is Student && SelectedCourse.Roster.Contains(SelectedPerson) == false)
            {
                SelectedCourse.Roster.Add(SelectedPerson);
                RefreshView();
            }
        }
    }
}
