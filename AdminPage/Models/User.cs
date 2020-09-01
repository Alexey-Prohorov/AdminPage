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

        [StringLength(20,MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        [Required(ErrorMessage = "Не указано имя")]
        public string name { get; set; }
        
        public string surname { get; set; }
        
        public string patronymic { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public string avatar { get; set; }
        public string mail { get; set; }

        public DateTime birthday { get; set; }

        public string sex { get; set; }
    }
}
