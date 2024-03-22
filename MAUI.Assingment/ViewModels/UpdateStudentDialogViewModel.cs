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
    public class UpdateStudentDialogViewModel
    {
        private Student? student;
        private PersonService personSvc;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Persons));
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
        public ObservableCollection<Person> Persons
        {
            get
            {
                return new ObservableCollection<Person>(personSvc.Persons);
            }
        }
        public Person SelectedPerson
        {
            get; set;
        }
        public UpdateStudentDialogViewModel()
        {
            student = new Student();
            personSvc = PersonService.Current;
        }
        public void UpdateStudent()
        {
            if (student != null)
            {
                SelectedPerson.Name = student.Name;
                SelectedPerson.Classification = student.Classification;
            }
        }
    }
}
