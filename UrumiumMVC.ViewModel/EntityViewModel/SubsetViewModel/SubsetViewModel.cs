using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;
using UrumiumMVC.DomainClasses.Entities.Visit;

namespace UrumiumMVC.ViewModel.EntityViewModel.SubsetViewModel
{
    public class SubsetViewModel
    {
        public int Id { get; set; }
        public List<VisitTime> AllVisitList { get; set; }
        public List<Doctorlistmoaref> alllistmoaref { get; set; }
    }
}
