using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Domain.Common
{
    public class PagingParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string PeriodField { get; set; } = string.Empty!;

        public DateRange Period { get; set; } = new DateRange();
        public string? SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public List<FilterItem> Filters { get; set; }
        public int PageIndex { get; set; }
    }

    public class DateRange
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsValid { get; set; }
    }

    public class FilterItem
    {
        public string Field { get; set; } = string.Empty; // Nombre de la columna en la DB
        public List<string> Selected { get; set; } = new List<string>(); // Valores seleccionados
        public FilterType Type { get; set; } // Enum para saber si es string, int, etc.
    }

    public enum FilterType
    {
        String,
        Integer,
        Boolean,
        Guid
    }
}
