using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Assignment1.Entities
{
    public class AssignmentSubmission
    {
        public Assignment Assignment { get; set; }
        public Student Student { get; set; }
        public DateTime DateTurnedIn { get; set; }
        public string Answer { get; set; }
        public int? Grade { get; set; }
        public AssignmentSubmission() 
        {
            DateTurnedIn = DateTime.Today;
            Grade = null;
        }
        public override string ToString()
        {
            return $"{DateTurnedIn} | {Student.Name} : {Answer} | Grade: {Grade}";
        }
    }
}
