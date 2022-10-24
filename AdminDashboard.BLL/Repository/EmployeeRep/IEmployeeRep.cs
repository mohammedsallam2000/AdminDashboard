using AdminDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.BLL.Repository.EmployeeRep
{
    public interface IEmployeeRep
    {
        IEnumerable<Employee> Get(Expression<Func<Employee, bool>> filter = null);
        IEnumerable<Employee> Search(Expression<Func<Employee, bool>> filter = null);

        Employee GetById(Expression<Func<Employee, bool>> filter = null);
        void Create(Employee model);
        void Edit(Employee model);
        void Delete(int id);
        void Delete(Employee model);
    }
}
