using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeSchoolPXL.Data.Repositories.Concrete
{
    public class CourseRepository : GenericRepository<Course, ApplicationDbContext>, ICourseRepository
    {
        private ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Course> GetCoursesWithHandbooks()
        {
            return _context.Courses.Include(c => c.Handbook).ToList();       
        }
    }
}
