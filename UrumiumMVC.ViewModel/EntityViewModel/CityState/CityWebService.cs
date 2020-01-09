using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;

namespace UrumiumMVC.ViewModel.EntityViewModel.CityState
{
    public class CityWebService
    {
        public List<CityWithoutFroegnkey> Cities { get; set; }
        public List<StateViewModel> States { get; set; }
    }
}
