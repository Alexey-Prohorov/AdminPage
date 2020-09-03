using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{
    public class FilterViewModel
    {
        public string SelectedName { get; private set; }    // введенное имя
        public int SelectedKolElementov { get; private set; } //количество отображаемых записей
        public FilterViewModel(string name, int kolElementov)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            SelectedName = name;
            SelectedKolElementov = kolElementov;
        }
    }
}
