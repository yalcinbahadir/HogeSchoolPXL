using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeSchoolPXL.Data.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepo { get;}
        IHandbookRepository HandbookRepo { get; }
        bool SaveChanges();
    }
}
