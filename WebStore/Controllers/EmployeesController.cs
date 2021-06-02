using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData)
        {
            _EmployeesData = EmployeesData;
        }

        public IActionResult Index() => View(_EmployeesData.GetAll());

        public IActionResult Details(int id)
        {
            var employee = _EmployeesData.Get(id);

            if (employee is null)
                return NotFound();

            return View(employee);
        }

        public IActionResult Create() => View();

        public IActionResult Edit(int id)
        {
            var employee = _EmployeesData.Get(id);
            if (employee is null) 
                return NotFound();

            var view_model = new EmployeeViewModel
            {
                Id = employee.Id,
                SurName = employee.SurName,
                Name = employee.Name,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                WorkExperience = employee.WorkExperience,
                Post = employee.Post,
                Education = employee.Education,
            };

            return View(view_model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel Model)
        {

            var employee = new Employee
            {
                Id = Model.Id,
                SurName = Model.SurName,
                Name = Model.Name,
                Patronymic = Model.Patronymic,
                Age = Model.Age,
                WorkExperience = Model.WorkExperience,
                Post = Model.Post,
                Education = Model.Education,
            };

            _EmployeesData.Update(employee);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) => View();
    }
}
