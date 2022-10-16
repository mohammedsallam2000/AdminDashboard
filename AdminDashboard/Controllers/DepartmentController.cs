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
    }
}
