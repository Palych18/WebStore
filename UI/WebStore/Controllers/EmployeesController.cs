using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;


namespace WebStore.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;
        private readonly ILogger<EmployeesController> _Logger;

        public EmployeesController(IEmployeesData EmployeesData, ILogger<EmployeesController> Logger)
        {
            _EmployeesData = EmployeesData;
            _Logger = Logger;
        }

        public IActionResult Index() => View(_EmployeesData.GetAll());

        public IActionResult Details(int id)
        {
            var employee = _EmployeesData.Get(id);

            if (employee is null)
                return NotFound();

            return View(employee);
        }

        [Authorize(Roles = Role.Administrators)]
        public IActionResult Create() => View("Edit", new EmployeeViewModel());

        [Authorize(Roles = Role.Administrators)]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new EmployeeViewModel());

            var employee = _EmployeesData.Get((int)id);
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
        [Authorize(Roles = Role.Administrators)]
        public IActionResult Edit(EmployeeViewModel Model)
        {
            if (!ModelState.IsValid)
                return View(Model);

            _Logger.LogInformation($"Редактирование сотрудника id: {Model.Id}.");

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

            if (employee.Id == 0)
                _EmployeesData.Add(employee);

            else
                _EmployeesData.Update(employee);

            _Logger.LogInformation($"Редактирование сотрудника id: {Model.Id} завершено.");

            return RedirectToAction("Index");
        }

        [Authorize(Roles = Role.Administrators)]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = _EmployeesData.Get(id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                SurName = employee.SurName,
                Name = employee.Name,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                WorkExperience = employee.WorkExperience,
                Post = employee.Post,
                Education = employee.Education,
            });
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrators)]
        public IActionResult DeleteConfirmed(int id)
        {
            _Logger.LogInformation($"Удаление сотрудника id: {id}.");
            _EmployeesData.Delete(id);
            _Logger.LogInformation($"Удаление сотрудника id: {id} завершено.");
            return RedirectToAction("Index");
        }
    }
}
