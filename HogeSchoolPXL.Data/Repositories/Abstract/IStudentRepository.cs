using HogeSchoolPXL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeSchoolPXL.Data.Repositories.Abstract
{
    public interface IStudentRepository :IRepository<Student>
    {
        Student GetByEmail(string email);
    }
}
