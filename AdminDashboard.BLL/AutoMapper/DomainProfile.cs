using AdminDashboard.BLL.Models;
using AdminDashboard.DAL.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.BLL.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Departments, DepartmentsVM>();
            CreateMap<DepartmentsVM, Departments>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();
        }


    }
}
