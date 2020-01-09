using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;

namespace UrumiumMVC.ViewModel.EntityViewModel.PharmacyViewModel
{
    public class PharmacyViewModel
    {
        public Pharmacy Pharmacies { get; set; }
        public List<State> States { get; set; }
    }
}
