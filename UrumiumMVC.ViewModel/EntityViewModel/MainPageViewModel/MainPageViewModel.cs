using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.DomainClasses.Entities.Group;
using UrumiumMVC.DomainClasses.Entities.judge;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;

namespace UrumiumMVC.ViewModel.EntityViewModel.MainPageViewModel
{
    public class MainPageViewModel
    {
        public List<Group> Groups { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<judge> Judges { get; set; }
        public List<Pharmacy> Pharmacies { get; set; }
        public List<City> Cities { get; set; }
        public int IllnessCount { get; set; }
        public string UserId { get; set; }
        public string UsetType { get; set; }
        public int IsLogin { get; set; }
    }
}
