using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Assignment1.Entities;
using Library.Assignment1.Services;

namespace MAUI.Assingment.ViewModels
{
    public class InstructorViewModel
    {
        private PersonService personSvc;

        public ObservableCollection<Instructor> Instructors
        {
            get
            {
                return new ObservableCollection<Instructor>(personSvc.Instructors);
            }
        }

        public InstructorViewModel()
        {
            personSvc = PersonService.Current;
        }
    }
}
