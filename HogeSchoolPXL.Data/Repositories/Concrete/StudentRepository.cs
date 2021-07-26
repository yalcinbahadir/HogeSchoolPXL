using HogeSchoolPXL.Data.Repositories.Abstract;
using HogeSchoolPXL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeSchoolPXL.Data.Repositories.Concrete
{
    public class StudentRepository : GenericRepository<Student, ApplicationDbContext>, IStudentRepository
    {
        private ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Student GetByEmail(string email)
        {
            return _context.Students.FirstOrDefault(s => s.Email == email);          
        }
    }
}
