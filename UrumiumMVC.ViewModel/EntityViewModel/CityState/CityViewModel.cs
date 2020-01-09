using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;

namespace UrumiumMVC.ViewModel.EntityViewModel.CityState
{
    public class CityViewModel
    {
        public List<City> Cities { get; set; }
        public List<State> States { get; set; }
    }
}
