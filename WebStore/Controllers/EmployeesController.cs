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
        private static readonly List<Employee> _Employee = new()
        {
            new Employee { Id = 1, SurName = "Васильев", Name = "Сергей", Patronymic = "Михайлович", Age = 25, WorkExperience = 3, Post = "Оператор", Education = "Среднее" },
            new Employee { Id = 2, SurName = "Матвеева", Name = "Алла", Patronymic = "Николаевна", Age = 31, WorkExperience = 8, Post = "Бухгалтер", Education = "Высшее" },
            new Employee { Id = 3, SurName = "Абдулова", Name = "Татьяна", Patronymic = "Игоревна", Age = 42, WorkExperience = 15, Post = "Директор", Education = "Высшее" },
            new Employee { Id = 4, SurName = "Есенин", Name = "Матвей", Patronymic = "Викторович", Age = 25, WorkExperience = 3, Post = "Оператор", Education = "Среднее" },
            new Employee { Id = 5, SurName = "Бочкарёв", Name = "Иван", Patronymic = "Андреевич", Age = 32, WorkExperience = 10, Post = "Менеджер", Education = "Высшее" }
        };
        public IActionResult Index()
        {
            return View(_Employee);
        }

        public IActionResult Details(int id)
        {
            var employee = _Employee.FirstOrDefault(employe => employe.Id == id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }
    }
}
