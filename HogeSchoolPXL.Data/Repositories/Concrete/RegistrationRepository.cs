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
    public class RegistrationRepository : GenericRepository<Registration, ApplicationDbContext>, IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Registration> GetRegistrationsWithStudentsAndCourses()
        {
            return _context.Registrations.Include(r=>r.Student).Include(r=>r.Course).ToList();
        }
    }
}
