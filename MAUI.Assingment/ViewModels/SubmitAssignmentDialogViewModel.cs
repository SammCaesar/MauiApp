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
    public class SubmitAssignmentDialogViewModel : INotifyPropertyChanged
    {
        private PersonService personSvc;
        private CourseService courseSvc;
        private Course? course;
        private Student? student;
        private AssignmentSubmission submission;
        public string Answer
        {
            get { return submission?.Answer ?? string.Empty; }
            set
            {
                if (submission == null) submission = new AssignmentSubmission();
                submission.Answer = value;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Assignment AssignmentSelected
        {
            get;
            set;
        }
        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                if (student != null && course != null)
                {
                    return new ObservableCollection<Assignment>(course.Assingments);

                }
                else
                {
                    return new ObservableCollection<Assignment> ();
                }
            }
        }
        public Student GetSelectedStudentFromService()
        {
            return personSvc.SelectedStudent;
        }
        public Course GetSelectedCourseFromService()
        {
            return courseSvc.SelectedCourse;
        }
        public SubmitAssignmentDialogViewModel()
        {
            personSvc = PersonService.Current;
            courseSvc = CourseService.Current;
            course = GetSelectedCourseFromService();
            student = GetSelectedStudentFromService();
        }
        public void RefreshView()
        {
            student = GetSelectedStudentFromService(); 
            course = GetSelectedCourseFromService();
            NotifyPropertyChanged(nameof(student));
            NotifyPropertyChanged(nameof(course));
            NotifyPropertyChanged(nameof(Assignments));
        }
        public void SubmitAssignment()
        {
            if (AssignmentSelected != null)
            {
                submission.Assignment = AssignmentSelected;
                submission.Student = student;
                AssignmentSelected.Submissions.Add(submission);
                RefreshView();
            }
        }
    }
}
