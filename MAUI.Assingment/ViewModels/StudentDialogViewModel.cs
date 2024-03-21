using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Assignment1.Entities;
using Library.Assignment1.Services;

namespace MAUI.Assingment.ViewModels
{
    public class StudentDialogViewModel
    {
        private Student? student;
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
        public int ID
        {
            get { return student.ID; }
            set 
            {
                if (student == null) student = new Student();
                student.ID = value; 
            }
        }

        public StudentDialogViewModel()
        {
            student = new Student();
        }
        public void AddStudent()
        {
            if (student != null)
            {
                PersonService.Current.Add(student);
            }
        }
    }
}
