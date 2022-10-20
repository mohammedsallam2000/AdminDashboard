using AdminDashboard.DAL.Database;
using AdminDashboard.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.BLL.Repository.EmployeeRep
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly AdminDashboardContext db;

        public EmployeeRep(AdminDashboardContext db)
        {
            this.db = db;
        }
        public void Create(Employee model)
        {
            db.Employee.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var OldData = db.Employee.Find(id);
            db.Employee.Remove(OldData);
            db.SaveChanges();

        }

        public void Delete(Employee model)
        {
            db.Employee.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Employee> Get(Expression<Func<Employee, bool>> filter = null)
        {
            if (filter == null )
            {
                var Data = db.Employee.Include("Departments").Select(x => x); // Get All Emplyees and department for each emplyee
                return Data;
            }
            else
            {
                var Data = db.Employee.Include("Departments").Where(filter); // Get All Emplyees and department for each emplyee
                return Data;
            }
               
        }

        public Employee GetById(int id)
        {
            var Data = db.Employee.Where(x => x.Id == id).FirstOrDefault();
            return Data;
        }

        public void Edit(Employee model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
