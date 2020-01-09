using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.DomainClasses.Entities.Illness;
using UrumiumMVC.DomainClasses.Entities.Noskhe;

namespace UrumiumMVC.ViewModel.EntityViewModel.NoskheViewModel
{
    public class NoskheViewModel
    {
        public int doctorid { get; set; }
        public int illnessid { get; set; }
        public int visitid { get; set; }
        public Doctor Doctorinfo { get; set; }
        public Illness Illnessinfo { get; set; }
        public Boolean Is_Finaly { get; set; }
        public string Date { get; set; }
        public string Peigiricode { get; set; }  
        public Boolean SendedTo_Pharmacy { get; set; }
        public List<Noskhe> NoskheMedicines { get; set; }
    }
}
