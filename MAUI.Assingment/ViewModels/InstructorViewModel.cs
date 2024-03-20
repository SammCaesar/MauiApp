using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Entities;
using Assignment1.Services;

namespace MAUI.Assingment.ViewModels
{
    internal class InstructorViewModel
    {
        private PersonService personSvc;

        public ObservableCollection<Person> Persons
        {
            get
            {
                return new ObservableCollection<Person>(personSvc.Persons);
            }
        }

        public InstructorViewModel()
        {
            personSvc = PersonService.Current;
        }
    }
}
