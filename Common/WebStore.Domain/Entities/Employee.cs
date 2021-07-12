using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    public class Employee : Entity
    {
        public string SurName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }        

        public string Patronymic { get; set; }

        public int Age { get; set; }

        public int WorkExperience { get; set; }  //опыт работы

        public string Post { get; set; }  //должность

        public string Education { get; set; }  //образование

        public override string ToString() => $"(id:{Id}) {SurName} {Name} {Patronymic} age:{Age}";
    }
}
