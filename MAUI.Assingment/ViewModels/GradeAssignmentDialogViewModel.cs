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
    class GradeAssignmentDialogViewModel
    {
        private PersonService personSvc;
        private CourseService courseSvc;
        private Course? course;
        private AssignmentSubmission submission;
        public int? Grade
        {
            get { return submission?.Grade ?? null; }
            set
            {
                if (submission == null) submission = new AssignmentSubmission();
                submission.Grade = value;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public AssignmentSubmission SelectedSubmission
        {
            get;
            set;
        }
        public ObservableCollection<AssignmentSubmission> Submissions
        {
            get
            {
                var subs = new ObservableCollection<AssignmentSubmission>();

                foreach (var course in courseSvc.Courses)
                {
                    foreach (var ass in course.Assingments)
                    {
                        ass.Submissions.ForEach(x => subs.Add(x));
                    }
                }
                return subs;
            }
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Submissions));
        }
        public GradeAssignmentDialogViewModel()
        {
            personSvc = PersonService.Current;
            courseSvc = CourseService.Current;
        }
        public void GradeSubmission()
        {
            if (SelectedSubmission != null)
            {
                SelectedSubmission.Grade = submission.Grade;
                RefreshView();
            }
        }
    }
}
