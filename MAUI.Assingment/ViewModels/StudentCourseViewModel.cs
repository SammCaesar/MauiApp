﻿using Library.Assignment1.Entities;
using Library.Assignment1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Assingment.ViewModels
{
    public class StudentCourseViewModel : INotifyPropertyChanged
    {
        private PersonService personSvc;
        private CourseService courseSvc;
        private Course? course;
        private Student? student;
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
                if (student != null)
                {
                    return new ObservableCollection<Course>(courseSvc.Courses
                    .ToList().Where(c => c?.Roster?.Contains(student) ?? false));
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
        public Student GetSelectedStudentFromService()
        {
            return personSvc.SelectedStudent;
        }
        public Course SelectedCourse
        {
            get; set;
        }
        public StudentCourseViewModel()
        {
            personSvc = PersonService.Current;
            courseSvc = CourseService.Current;
            student = GetSelectedStudentFromService();
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Students));
            NotifyPropertyChanged(nameof(Persons));
            NotifyPropertyChanged(nameof(Courses));
        }
    }
}
