using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.WebServiceClasses
{
    public class PharmacyWebService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public string ActiveCode { get; set; }
    }
}
