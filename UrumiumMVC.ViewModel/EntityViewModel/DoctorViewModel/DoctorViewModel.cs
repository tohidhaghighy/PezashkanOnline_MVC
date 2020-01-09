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
    public class DoctorViewModel
    {
        public Doctor doctor { get; set; }
        public List<State> States { get; set; }
        public List<Group> Groups { get; set; }
        public List<DoctorDays> DoctorDays { get; set; }
        public List<Day> Days { get; set; }
    }
}
