using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Doctor;

namespace UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel
{
    public class DoctorDetailViewModel
    {
        public Doctor Doctors { get; set; }
        public List<DoctorDays> DoctorDays { get; set; }
    }
}
