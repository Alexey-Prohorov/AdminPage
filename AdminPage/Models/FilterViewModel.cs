using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            SelectedName = name;
        }
        public string SelectedName { get; private set; }    // введенное имя
    }
}
