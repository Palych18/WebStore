using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Services.Interfaces;

namespace WebStore.Services.InSQL
{
    public class SqlEmployeesData : IEmployeesData
    {
        private readonly WebStoreDB _db;
        private readonly ILogger<SqlEmployeesData> _Logger;

        public SqlEmployeesData(WebStoreDB db, ILogger<SqlEmployeesData> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public IEnumerable<Employee> GetAll() => _db.Employees.ToArray();

        public Employee Get(int id) => _db.Employees.SingleOrDefault(employee => employee.Id == id);

        public int Add(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));

            _db.Add(employee);

            _db.SaveChanges();

            _Logger.LogInformation($"Сотрудник id:{employee} добавлен");

            return employee.Id;
        }

        public void Update(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));

            _db.Update(employee);

            _Logger.LogInformation($"Сотрудник id:{employee} отредактирован");

            _db.SaveChanges();
        }

        public bool Delete(int id)
        {

            var employee = _db.Employees
               .Select(e => new Employee { Id = e.Id })
               .FirstOrDefault(e => e.Id == id);
            if (employee is null) return false;
            
            _db.Remove(employee);

            _db.SaveChanges();

            _Logger.LogInformation($"Сотрудник id:{id} удалён");

            return true;
        }
    }
}
