using AdminDashboard.BLL.Models;
using AdminDashboard.BLL.Repository.DepartmentRepo;
using AdminDashboard.DAL.Database;
using AdminDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.BLL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly AdminDashboardContext db;

        public DepartmentRep(AdminDashboardContext db)
        {
            this.db = db;
        }
        public void Create(DepartmentsVM model)
        {
            Departments obj = new Departments();
            obj.Name = model.Name;
            obj.Code = model.Code;
            db.Departments.Add(obj);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var OldData = db.Departments.Find(id);
            db.Departments.Remove(OldData);
            db.SaveChanges();

        }

        public void Delete(DepartmentsVM model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentsVM> Get()
        {
            var Data = db.Departments.Select(x => new DepartmentsVM { Id = x.Id, Name = x.Name, Code = x.Code });
            return Data;
        }

        public DepartmentsVM GetById(int id)
        {
            var Data = db.Departments.Where(x=>x.Id==id).Select(x => new DepartmentsVM { Id = x.Id, Name = x.Name, Code = x.Code }).FirstOrDefault();
            return Data;
        }
         
        public void Update(DepartmentsVM model)
        {
            var OldData = db.Departments.Find(model.Id);
            OldData.Name = model.Name;
            OldData.Code = model.Code;
            db.SaveChanges();
        }
    }
}
