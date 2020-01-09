using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.PharmacyMassage
{
    public class PharmacyMassegeListViewModel
    {
        public int Illnessid { get; set; }
        public string Illnessname { get; set; }
        public string Text { get; set; }
        public int Visitid { get; set; }
        public int Doctorid { get; set; }
    }
}
