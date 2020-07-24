using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{
    public class User
    {
        public int id { get; set; }
        
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
