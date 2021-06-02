using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public int Age { get; set; }

        public int WorkExperience { get; set; }

        public string Post { get; set; }

        public string Education { get; set; }
    }
}
