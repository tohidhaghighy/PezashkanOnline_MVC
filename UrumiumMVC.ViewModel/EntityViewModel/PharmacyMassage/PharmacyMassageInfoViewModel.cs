using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;

namespace UrumiumMVC.ViewModel.EntityViewModel.PharmacyMassage
{
    public class PharmacyMassageInfoViewModel
    {
        public int Illnessid { get; set; }
        public string Illnessname { get; set; }
        public int Doctorid { get; set; }
        public int Visitid { get; set; }
        public string Date { get; set; }
        public List<Pharmacy_Massage> PhamacyMassageList { get; set; }
    }
}
