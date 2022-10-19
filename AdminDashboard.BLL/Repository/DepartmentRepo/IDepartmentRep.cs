using AdminDashboard.BLL.Models;
using AdminDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.BLL.Repository.DepartmentRepo
{
    public interface IDepartmentRep
    {

        IEnumerable<Departments> Get();
        Departments GetById(int id);
        void Create(Departments model);
        void Update(Departments model);
        void Delete(int id);
        void Delete(Departments model);

    }
}
