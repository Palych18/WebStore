using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {        
        public IActionResult Index()
        {
            return View(_Employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _Employees.FirstOrDefault(employe => employe.Id == id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }
    }
}
