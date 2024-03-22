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
    public class AssignmentDialogViewModel
    {
        private CourseService courseSvc;
        private Assignment? assignment;
        public string Name
        {
            get { return assignment?.Name ?? string.Empty; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.Name = value;
            }
        }
        public string Description
        {
            get { return assignment?.Description ?? string.Empty; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.Description = value;
            }
        }
        public int TotalAvailablePoints
        {
            get { return assignment?.TotalAvailablePoints ?? 100; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.TotalAvailablePoints = value;
            }
        }
        public DateTime DueDate
        {
            get { return assignment?.DueDate ?? DateTime.MinValue; }
            set
            {
                if (assignment == null) assignment = new Assignment();
                assignment.DueDate = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Course SelectedCourse
        {
            get; set;
        }
        public AssignmentDialogViewModel()
        {
            courseSvc = CourseService.Current;
            assignment = new Assignment();
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
        public void AddAssignment()
        {
            if (assignment != null)
            {
                SelectedCourse.Assingments.Add(assignment);
                RefreshView();
            }
        }
    }
}
