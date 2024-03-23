using System;
using System.Collections;
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
        private Course? course;
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
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Course> Courses
        {
            get
            {
                if (SelectedStudent != null)
                {
                    return new ObservableCollection<Course>(courseSvc.Courses
                    .ToList().Where(c => c?.Roster?.Contains(SelectedStudent) ?? false));
                }
                else
                {
                    return new ObservableCollection<Course>();
                }
            }
        }
        public ObservableCollection<Person> Persons
        {
            get
            {
                return new ObservableCollection<Person>(personSvc.Persons);
            }
        }
        public ObservableCollection<Student> Students
        {
            get
            {
                return new ObservableCollection<Student>(personSvc.Students);
            }
        }
        public Student SelectedStudent
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
            NotifyPropertyChanged(nameof(Students));
            NotifyPropertyChanged(nameof(Persons));
            NotifyPropertyChanged(nameof(Courses));
        }
    }
}
