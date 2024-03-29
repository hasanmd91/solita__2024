using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBike.Core.src.Shared
{
    public class GetAllOptions
    {
        public int Limit { get; set; } = 20;
        public int Offset { get; set; } = 0;
        public string? OrderBy { get; set; }
        public string? SortDirection { get; set; }
    }
}