using AdminDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.BLL.Repository.EmployeeRep
{
    public interface IEmployeeRep
    {
        IEnumerable<Employee> Get();
        Employee GetById(int id);
        void Create(Employee model);
        void Edit(Employee model);
        void Delete(int id);
        void Delete(Employee model);
    }
}
