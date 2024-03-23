using Library.Assignment1.Entities;

namespace Library.Assignment1.Services
{
	public class CourseService
	{
		private IList<Course> courses;

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
				return courses ?? new List<Course>();
			}
		}
		public IEnumerable<string> DetailedCourses
		{
			get
			{
				return courses.Select(x => x.DetailedView()).ToList() ?? new List<string>();
			}
		}
		private CourseService()
		{
			courses = new List<Course>();
			var mills = new Course()
			{
				Code = "101",
				Name = "C# FullStack Development",
				Description = "Chris Mills teaches C# and MAUI FullStack Development.",
			};
			var sharanya = new Course()
			{
				Code = "202",
				Name = "Parallel Programming",
				Description = "Sharanya Jayaraman teaches Parallel Programming in Python",
			};
			courses.Add(mills);
			courses.Add(sharanya);
		}

        public Course? GetByID(int Id)
        {
			return Courses.FirstOrDefault(p => p.ID == Id);
        }

        public IEnumerable<Course> Search(string query)
		{
            return Courses.Where(c =>
			c.Name.ToUpper().Contains(query.ToUpper())
			|| c.Description.ToUpper().Contains(query.ToUpper()));
        }

		public void Add(Course myCourse)
		{
            if (myCourse.ID == 0)
            {
                myCourse.ID = LastId + 1;
            }
            courses.Add(myCourse);
        }

        private int LastId
        {
            get
            {
                return Courses.Any() ? Courses.Select(c => c.ID).Max() : 0;
            }
        }

        public void Remove(Course myCourse)
        {
            courses.Remove(myCourse);
        }
    }
}

