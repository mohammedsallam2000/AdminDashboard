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

        public AdminDashboardContext(DbContextOptions<AdminDashboardContext> opt) : base(opt)
        {

        }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<District> District { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=AdminDashboardDB;integrated security =true");
        //}
    }
}
