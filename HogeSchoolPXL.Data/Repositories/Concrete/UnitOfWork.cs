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

        public UnitOfWork(ApplicationDbContext context, 
                          IStudentRepository students, 
                          IHandbookRepository handbooks)
        {
            _context = context;
            _students = students;
            _handbooks = handbooks;
        }

        public IStudentRepository StudentRepo => _students;
        public IHandbookRepository HandbookRepo => _handbooks;

        public bool SaveChanges()
        {
            return _context.SaveChanges()>0;          
        }
    }
}
