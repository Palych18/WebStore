using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class EmployeeViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name ="Фамилия")]
        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(200, MinimumLength = 2, ErrorMessage ="Длина фамилии от 2 до 200 символов")]
        [RegularExpression(@"([A-Z][a-z]+)|([А-ЯЁ][а-яё]+)", ErrorMessage = "Не верный формат фамилии")]
        public string SurName { get; set; }

        [Display(Name ="Имя")]
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длина имени от 2 до 200 символов")]
        [RegularExpression(@"([A-Z][a-z]+)|([А-ЯЁ][а-яё]+)", ErrorMessage = "Не верный формат имени")]
        public string Name { get; set; }

        [Display(Name ="Отчество")]
        [Required(ErrorMessage = "Не указано отчество")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длина отчества от 2 до 200 символов")]
        [RegularExpression(@"([A-Z][a-z]+)|([А-ЯЁ][а-яё]+)", ErrorMessage = "Не верный формат отчества")]
        public string Patronymic { get; set; }

        [Display(Name = "Возраст")]
        [Range(18, 70, ErrorMessage = "Возраст должен быть от 18 до 70 лет")]
        public int Age { get; set; }

        [Display(Name = "Стаж")]
        public int WorkExperience { get; set; }

        [Display(Name = "Должность")]
        public string Post { get; set; }

        [Display(Name = "Образование")]
        public string Education { get; set; }
    }
}
