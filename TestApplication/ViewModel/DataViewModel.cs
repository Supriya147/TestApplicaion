using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.ViewModel
{
    public class DataViewModel : Employee
    {
        public List<DataViewModel> data { get; set; }
        public string[] lstHobbiesString { get; set; }
        public string JSONData { get; set; }
    }
}
