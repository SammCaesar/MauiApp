using System;
namespace Library.Assignment1.Entities
{
	public class Assignment
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }
        public List<AssignmentSubmission> Submissions { get; set; }
        public Assignment()
		{
		}
        public override string ToString()
        {
            string r = $"{Name} Description: {Description}\nTotal Available Points: {TotalAvailablePoints} Due Date: {DueDate}\nSubmissions:\n";
            foreach (var sub in Submissions)
            {
                r += sub.ToString() + "\n";
            }
            return r;
        }
    }
}

