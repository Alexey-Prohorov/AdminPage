using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{
    public class User
    {
        [BindNever] //исключить из механизма привязки
        public int id { get; set; }

        [StringLength(20,MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        [Required(ErrorMessage = "Не указано имя")]
        public string name { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 20 символов")]
        public string surname { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 20 символов")]
        public string patronymic { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        public string login { get; set; }


        public string password { get; set; }

        public string avatar { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string mail { get; set; }

        public DateTime birthday { get; set; }

        public string sex { get; set; }
    }
}
