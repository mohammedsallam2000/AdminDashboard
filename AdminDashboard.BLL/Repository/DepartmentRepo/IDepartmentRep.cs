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

        IEnumerable<DepartmentsVM> Get();
        DepartmentsVM GetById(int id);
        void Create(DepartmentsVM model);
        void Update(DepartmentsVM model);
        void Delete(int id);
        void Delete(DepartmentsVM model);

    }
}
