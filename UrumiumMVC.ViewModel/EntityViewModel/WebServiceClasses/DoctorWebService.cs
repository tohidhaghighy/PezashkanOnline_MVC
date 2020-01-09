using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.WebServiceClasses
{
    public class DoctorWebService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Takhasos { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Cost { get; set; }
        public string City { get; set; }
    }
}
