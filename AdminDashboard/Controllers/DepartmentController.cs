using AdminDashboard.BLL.Models;
using AdminDashboard.BLL.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentRep department = new DepartmentRep();
        public IActionResult Index()
        {
            var data = department.Get();
            return View(data);
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
                    department.Create(model);
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
            return View(data);
        }



        public IActionResult Update(int id)
        {
            var data = department.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(DepartmentsVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Update(model);
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
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(DepartmentsVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Delete(model.Id);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }
    }
}
