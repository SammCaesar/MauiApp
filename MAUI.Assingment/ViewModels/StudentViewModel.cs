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
    public class StudentViewModel : INotifyPropertyChanged
    {
        private PersonService personSvc;
        private CourseService courseSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(courseSvc.Courses);
            }
        }
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
                return new ObservableCollection<Student>(personSvc.Students);
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
        public StudentViewModel()
        {
            personSvc = PersonService.Current;
            courseSvc = CourseService.Current;
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Persons));
            NotifyPropertyChanged(nameof(Courses));
            NotifyPropertyChanged(nameof(DetailedCourses));
        }
    }
}
