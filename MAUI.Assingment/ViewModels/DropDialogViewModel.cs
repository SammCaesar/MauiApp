using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Library.Assignment1.Entities;
using Library.Assignment1.Services;

namespace MAUI.Assingment.ViewModels
{
    public class DropDialogViewModel
    {
        private Student? student; 
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
        public string Name
        {
            get { return student?.Name ?? string.Empty; }
            set
            {
                if (student == null) student = new Student();
                student.Name = value;
            }
        }
        public string Grade
        {
            get { return student?.Grade ?? string.Empty; }
            set
            {
                if (student == null) student = new Student();
                student.Grade = value;
            }
        }
        public Course SelectedCourse
        {
            get; set;
        }
        public DropDialogViewModel()
        {
            student = new Student();
            courseSvc = CourseService.Current;
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Courses));
        }
        public void DropStudent()
        {
            if (SelectedCourse != null && student != null)
            {
                int x = -1;

                for (int i = 0; i < SelectedCourse.Roster.Count(); i++)
                {
                    if (student.Name == SelectedCourse.Roster[i].Name)
                    {
                        x = i;
                    }
                }

                SelectedCourse.Roster.RemoveAt(x);
                RefreshView();
            }
        }
    }
}
