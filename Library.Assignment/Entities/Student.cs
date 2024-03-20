using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.Assignment1.Entities
{
    public class Student : Person
    {
        public Dictionary<string, char> Grades { get; set; } // Class, Grade (A-F)
        public string Grade { get; set; } // Freshamn/Sophmore/Junior/Senior

        public Student() 
        {
            Grades = new Dictionary<string, char>();
        }

        public override string ToString()
        {
            return $"[{ID}] {Name} | {Classification} | {Grade}";
        }
    }
}
