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
    public class HandbookRepository : GenericRepository<Handbook, ApplicationDbContext>, IHandbookRepository
    {
        private readonly ApplicationDbContext _context;

        public HandbookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Handbook> GetHandbooksWithCourses()
        {
           return  _context.Handbooks.Include(hb => hb.Course).ToList();           
        }
    }
}
