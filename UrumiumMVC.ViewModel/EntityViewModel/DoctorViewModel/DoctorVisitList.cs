using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.ViewModel.EntityViewModel.VisitViewModel;

namespace UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel
{
    public class DoctorVisitList
    {
        public List<VisitListViewModel> visitlist { get; set; }
        public string Mobile { get; set; }
    }
}
