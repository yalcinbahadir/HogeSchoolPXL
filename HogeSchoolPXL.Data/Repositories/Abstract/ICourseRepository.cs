using HogeSchoolPXL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeSchoolPXL.Data.Repositories.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        List<Course> GetCoursesWithHandbooks();
    }
}
