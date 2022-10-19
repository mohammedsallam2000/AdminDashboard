using AdminDashboard.BLL.Models;
using AdminDashboard.BLL.Repository.DepartmentRepo;
using AdminDashboard.DAL.Database;
using AdminDashboard.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.BLL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly AdminDashboardContext db;

        public DepartmentRep(AdminDashboardContext db)
        {
            this.db = db;
        }
        public void Create(Departments model)
        {
            db.Departments.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var OldData = db.Departments.Find(id);
            db.Departments.Remove(OldData);
            db.SaveChanges();

        }

        public void Delete(Departments model)
        {
            db.Departments.Remove(model);
            db.SaveChanges();
        }

        public IEnumerable<Departments> Get()
        {
            var Data = db.Departments.Select(x => x);
            return Data;
        }

        public Departments GetById(int id)
        {
            var Data = db.Departments.Where(x=>x.Id==id).FirstOrDefault();
            return Data;
        }
         
        public void Update(Departments model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
