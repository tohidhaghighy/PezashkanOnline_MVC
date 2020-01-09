using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;

namespace UrumiumMVC.ViewModel.EntityViewModel.Marketing
{
    public class Marketing
    {
        public int CostOffer { get; set; }
        public int CountZirmajmoee { get; set; }
        public Doctor Doctors { get; set; }
        public List<Doctorlistmoaref> DoctorList { get; set; }
    }
}
