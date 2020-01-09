using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.DomainClasses.Entities.Group;

namespace UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel
{
    public class DoctorListViewModel
    {
        public List<Group> Groups { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<City> Cities { get; set; }
    }
}
