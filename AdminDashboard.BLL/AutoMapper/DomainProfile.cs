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

            CreateMap<City, CityVM>();
            CreateMap<CityVM, City>();

            CreateMap<Country, CountryVM>();
            CreateMap<Country, CountryVM>();


            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();
        }


    }
}
