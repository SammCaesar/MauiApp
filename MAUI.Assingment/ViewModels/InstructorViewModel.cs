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

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public InstructorViewModel()
        {
            personSvc = PersonService.Current;
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Persons));
            //NotifyPropertyChanged(nameof(Students));
        }
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
    }
}
