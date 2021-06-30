﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Services.Interfaces;
using WebStore.WebAPI.Clients.Base;

namespace WebStore.WebAPI.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        public EmployeesClient(HttpClient Client) : base(Client, "api/employees")
        {

        }

        public int Add(Employee employee)
        {
            var response = Post(Address, employee);
            var id = response.Content.ReadFromJsonAsync<int>().Result;
            return id;
        }

        public bool Delete(int id)
        {
            var result = Delete($"{Address}/{id}").IsSuccessStatusCode;
            return result;
        }

        public Employee Get(int id)
        {
            return Get<Employee>($"{Address}/{id}");
        }
                
        public IEnumerable<Employee> GetAll()
        {
            return Get<IEnumerable<Employee>>(Address);
        }

        public void Update(Employee employee)
        {
            Put(Address, employee);
        }
    }
}
