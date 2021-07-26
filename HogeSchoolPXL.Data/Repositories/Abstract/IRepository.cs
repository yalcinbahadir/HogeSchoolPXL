﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogeSchoolPXL.Data.Repositories.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        bool Create(T entity);
        bool Update(T entity);
        void Delete(T entity);
    }
}
