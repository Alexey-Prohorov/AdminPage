using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{
    public class IndexViewModel
    {
        public IEnumerable<User> User { get; set; }
        public SortViewModel  SortViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public string Name { get; set; }

    }
}
