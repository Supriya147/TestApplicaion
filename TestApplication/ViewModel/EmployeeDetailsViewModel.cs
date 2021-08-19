using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Models;
using Microsoft.AspNetCore.Http;

namespace TestApplication.ViewModel
{
    public class EmployeeDetailsViewModel : EmployeeDetails
    {
        public string title { get; set; }
        public int EmpId {get;set; }
        public string RelatedId { get; set; }
        public IFormFile File { get; set; }
        public string Url { get; set; }
        public class EmployeeDetailsListViewModel
        {
            public List<EmployeeDetailsViewModel> EmployeeDetailsViewModels { get; set; }
            public string title { get; set; }
            public string RelatedId { get; set; }

        }
    }
}
