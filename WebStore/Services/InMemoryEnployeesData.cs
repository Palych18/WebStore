using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
using WebStore.Services.Interfaces;


namespace WebStore.Services
{
    public class InMemoryEnployeesData : IEmployeesData
    {

        private readonly List<Employee> _Employees = new()
        {
            new Employee { Id = 1, SurName = "Васильев", Name = "Сергей", Patronymic = "Михайлович", Age = 25, WorkExperience = 3, Post = "Оператор", Education = "Среднее" },
            new Employee { Id = 2, SurName = "Матвеева", Name = "Алла", Patronymic = "Николаевна", Age = 31, WorkExperience = 8, Post = "Бухгалтер", Education = "Высшее" },
            new Employee { Id = 3, SurName = "Абдулова", Name = "Татьяна", Patronymic = "Игоревна", Age = 42, WorkExperience = 15, Post = "Директор", Education = "Высшее" },
            new Employee { Id = 4, SurName = "Есенин", Name = "Матвей", Patronymic = "Викторович", Age = 25, WorkExperience = 3, Post = "Оператор", Education = "Среднее" },
            new Employee { Id = 5, SurName = "Бочкарёв", Name = "Иван", Patronymic = "Андреевич", Age = 32, WorkExperience = 10, Post = "Менеджер", Education = "Высшее" }
        };

        private int _CurrentMaxId;

        public InMemoryEnployeesData()
        {
            _CurrentMaxId = _Employees.Max(i => i.Id);
        }

        public int Add(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));

            if (_Employees.Contains(employee)) return employee.Id;

            employee.Id = ++_CurrentMaxId;
            _Employees.Add(employee);

            return employee.Id;
        }

        public bool Delete(int id)
        {
            var db_item = Get(id);
            if (db_item is null) return false;
            return _Employees.Remove(db_item);
        }

        public Employee Get(int id) => _Employees.SingleOrDefault(employee => employee.Id == id);

        public IEnumerable<Employee> GetAll() => _Employees;
        

        public void Update(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));

            if (_Employees.Contains(employee)) return;

            var db_item = Get(employee.Id);
            if (db_item is null) return;

            db_item.SurName = employee.SurName;
            db_item.Name = employee.Name;
            db_item.Patronymic = employee.Patronymic;
            db_item.Age = employee.Age;
            db_item.WorkExperience = employee.WorkExperience;
            db_item.Post = employee.Post;
            db_item.Education = employee.Education;
        }
    }
}
