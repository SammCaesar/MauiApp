using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Entities;

namespace MAUI.Assingment.ViewModels
{
    internal class InstructorViewModel
    {
        private Person instructor;  

        public string InstructorName
        {
            get
            {
                return instructor?.Name ?? string.Empty;
            }
            set
            {
                instructor.Name = value;
            }
        }
        public InstructorViewModel()
        {
            instructor = new Person { Name = "My test instructor" };
        }
    }
}
