using AdminDashboard.BLL.Models;
using AdminDashboard.BLL.Repository;
using AdminDashboard.BLL.Repository.DepartmentRepo;
using AdminDashboard.DAL.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Controllers
{
    public class DepartmentController : Controller
    {
        #region Fields
        // Losly Coupled
        private readonly IDepartmentRep department;
        private readonly IMapper mapper;
        #endregion

        #region Ctor
        public DepartmentController(IDepartmentRep department, IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            var data = department.Get();
            var model = mapper.Map<IEnumerable<DepartmentsVM>>(data);
            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentsVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Departments>(model);
                    department.Create(data);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }


        public IActionResult Details(int id)
        {
            var data = department.GetById(id);
            var model = mapper.Map<DepartmentsVM>(data);
            return View(model);
        }



        public IActionResult Update(int id)
        {
            var data = department.GetById(id);
            var model = mapper.Map<DepartmentsVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(DepartmentsVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Departments>(model);
                    department.Update(data);
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
            var data = department.GetById(id);
            var model = mapper.Map<DepartmentsVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(DepartmentsVM model)
        {
            try
            {
                var data = mapper.Map<Departments>(model);
                department.Delete(data);
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
