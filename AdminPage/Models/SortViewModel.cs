using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; set; } // Значение для сортировки по 
        public SortState Current { get; set; } //значение свойства, выбранного для сортировки
        public bool Up { get; set; }

        public SortViewModel (SortState sortOrder)
        {
            //значение по умолчанию
            NameSort = SortState.NameAsc;
            Up = true;
            if (sortOrder == SortState.NameDesc || sortOrder == SortState.SurnameDesc)
                Up = false;
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    Current = NameSort = SortState.NameAsc;
                    break;
                default:
                    Current = NameSort = SortState.NameDesc;
                    break;
            }
        }
    }
}
