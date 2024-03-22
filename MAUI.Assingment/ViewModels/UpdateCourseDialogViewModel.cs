using Library.Assignment1.Entities;
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
    public class UpdateCourseDialogViewModel
    {
        private Course? course;
        private CourseService courseSvc;
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
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Courses));
        }
        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(courseSvc.Courses);
            }
        }
        public Course SelectedCourse
        {
            get; set;
        }
        public UpdateCourseDialogViewModel()
        {
            course = new Course();
            courseSvc = CourseService.Current;
        }
        public void UpdateCourse()
        {
            if (course != null)
            {
                SelectedCourse.Code = course.Code;
                SelectedCourse.Name = course.Name;
                SelectedCourse.Description = course.Description;
            }
        }
    }
}
