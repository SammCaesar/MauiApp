using Assignment1.Entities;

namespace Assignment1.Services
{
	public class CourseService
	{
		private IList<Course> courses;

		private string? query;
		private static object _lock = new object();
		private static CourseService? instance;
		public static CourseService Current
		{
			get
			{
				lock(_lock)
				{
                    if (instance == null)
                    {
                        instance = new CourseService();
                    }
                }
				return instance;
			}
		}

		public IEnumerable<Course> Courses
		{
			get
			{
				return courses.Where(
					c =>
						c.Name.ToUpper().Contains(query.ToUpper() ?? string.Empty)
						|| c.Description.ToUpper().Contains(query.ToUpper() ?? string.Empty));
			}
		}

		private CourseService()
		{
			courses = new List<Course>();
		}

        public IEnumerable<Course> GetByPerson(Guid personId)
        {
            return courses.Where(p => p.PersonID == personId);
        }

        public IEnumerable<Course> Search(string query)
		{
			this.query = query;
			return Courses;
		}

		public void Add(Course myCourse)
		{
			courses.Add(myCourse);
        }

        public void Remove(Course myCourse)
        {
            courses.Remove(myCourse);
        }
    }
}

