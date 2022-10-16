using AdminDashboard.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.DAL.Database
{
    public class AdminDashboardContext : DbContext
    {
        public DbSet<Departments> Departments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=AdminDashboardDB;integrated security =true");
        }
    }
}
