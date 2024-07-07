using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidIspitniProjekat.Business.DTO
{
    public class ApiResponse<T>
    {
        public List<T> Data { get; set; }
        public int PerPage { get; set; }
        public int TotalCount { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
