using HogeSchoolPXL.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeSchoolPXL.Data.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private IStudentRepository _students;
        private IHandbookRepository _handbooks;
        private ICourseRepository _courses;
        private IRegistrationRepository _registrations;

        public UnitOfWork(ApplicationDbContext context, 
                          IStudentRepository students, 
                          IHandbookRepository handbooks, 
                          ICourseRepository courses, 
                          IRegistrationRepository registrations)
        {
            _context = context;
            _students = students;
            _handbooks = handbooks;
            _courses = courses;
            _registrations = registrations;
        }

        public IStudentRepository StudentRepo => _students;
        public IHandbookRepository HandbookRepo => _handbooks;
        public ICourseRepository CourseRepo => _courses;
        public IRegistrationRepository RegistrationRepo => _registrations;

        public bool SaveChanges()
        {
            return _context.SaveChanges()>0;          
        }
    }
}
