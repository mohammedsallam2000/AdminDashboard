using AdminDashboard.BLL.Models;
using AdminDashboard.BLL.Repository.DepartmentRepo;
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

        private readonly IMapper mapper;
        #endregion

        #region Ctor
        public EmployeeController(IEmployeeRep employee,IDepartmentRep department, IMapper mapper)
        {
            this.employee = employee;
            this.department = department;
            this.mapper = mapper;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            var data = employee.Get(x=>x.IsDeleted == false && x.IsActive == true);
            var model = mapper.Map<IEnumerable<EmployeeVM>>(data);
            return View(model);
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
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = employee.GetById(x => x.Id == id && x.IsDeleted == false && x.IsActive == true);
            var model = mapper.Map<EmployeeVM>(data);
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
                return View(model);
            }
        }
        #endregion
    }
}
