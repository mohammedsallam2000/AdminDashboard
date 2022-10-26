using AdminDashboard.BLL.Models;
using AdminDashboard.BLL.Repository.CityRep;
using AdminDashboard.BLL.Repository.DepartmentRepo;
using AdminDashboard.BLL.Repository.DistrictRep;
using AdminDashboard.BLL.Repository.EmployeeRep;
using AdminDashboard.DAL.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Controllers
{
    public class EmployeeController : Controller
    {
        #region Fields
        // Losly Coupled
        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        private readonly IMapper mapper;
        #endregion

        #region Ctor
        public EmployeeController(IEmployeeRep employee,IDepartmentRep department, ICityRep city, IDistrictRep district, IMapper mapper)
        {
            this.employee = employee;
            this.department = department;
            this.city = city;
            this.district = district;
            this.mapper = mapper;
        }
        #endregion

        #region Actions
        public IActionResult Index(string SearchValue)
        {
            if (SearchValue == null)
            {
                var data = employee.Get(x => x.IsDeleted == false && x.IsActive == true);
                var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(model);
            }
            else
            {
                var data = employee.Search(x => x.Name == SearchValue || x.Email == SearchValue || x.Address == SearchValue || x.Salary.ToString() == SearchValue || x.Departments.Name == SearchValue);
                var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(model);
            }
        }


        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(department.Get(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    employee.Create(data);
                    return RedirectToAction("Index");
                }
                ViewBag.Departments = new SelectList(department.Get(), "Id", "Name");

                return View(model);
            }
            catch (Exception)
            {
                ViewBag.Departments = new SelectList(department.Get(), "Id", "Name");

                return View(model);
            }
        }


        public IActionResult Details(int id)
        {
            var data = employee.GetById(x => x.Id == id && x.IsDeleted == false && x.IsActive == true);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.Departments = new SelectList(department.Get(), "Id", "Name",model.DepartmentId);

            return View(model);
        }



        public IActionResult Edit(int id)
        {
            var data = employee.GetById(x => x.Id == id && x.IsDeleted == false && x.IsActive == true);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.Departments = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    employee.Edit(data);
                    return RedirectToAction("Index");
                }
                ViewBag.Departments = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);

                return View(model);
            }
            catch (Exception)
            {
                ViewBag.Departments = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);

                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = employee.GetById(x => x.Id == id && x.IsDeleted == false && x.IsActive == true);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.Departments = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);

            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeVM model)
        {
            try
            {
                var data = mapper.Map<Employee>(model);
                employee.Delete(data);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.Departments = new SelectList(department.Get(), "Id", "Name", model.DepartmentId);

                return View(model);
            }
        }
        #endregion

        #region Ajax Call 

        // Get City Data By CountryId
        [HttpPost]
        public JsonResult GetCityByCountryId(int CntryId)
        {
            var data = city.Get(x=>x.CountryId == CntryId);
            var model = mapper.Map<IEnumerable<CityVM>>(data);
            return Json(model);
        }

        // Get Country Data By CityId
        [HttpPost]
        public JsonResult GetDistrictByCityId(int CtyId)
        {
            var data = district.Get(x => x.CityId == CtyId);
            var model = mapper.Map<IEnumerable<DistrictVM>>(data);
            return Json(model);
        }

        #endregion
    }
}
