using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.VisitViewModel
{
    public class VisitListViewModel
    {
        public int Id { get; set; }
        public string IllnessName { get; set; }
        public string DoctorName { get; set; }
        public int IllnessId { get; set; }
        public int DoctorId { get; set; }
        public Boolean Is_Visit_Finish { get; set; }
        public Boolean Is_Pay { get; set; }
        public string ReserveTime { get; set; }
        public string Code { get; set; }
    }
}
