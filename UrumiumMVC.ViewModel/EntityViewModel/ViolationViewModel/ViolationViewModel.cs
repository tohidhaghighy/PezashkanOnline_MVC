using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.ViolationViewModel
{
    public class ViolationViewModel
    {
        public int Id { get; set; }
        public bool Check { get; set; }
        public string Number { get; set; }
        public string IllnessName { get; set; }
        public string DoctorName { get; set; }
        public string IllnessDescription { get; set; }
        public bool AdminDescription { get; set; }
        public string AdminAnswer { get; set; }
        public string TypePm { get; set; }
        public int VisitId { get; set; }
        public int IllnessId { get; set; }
        public int DoctorId { get; set; }
    }
}
