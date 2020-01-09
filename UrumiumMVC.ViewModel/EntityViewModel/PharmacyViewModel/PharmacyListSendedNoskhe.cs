using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Noskhe;

namespace UrumiumMVC.ViewModel.EntityViewModel.PharmacyViewModel
{
    public class PharmacyListSendedNoskhe
    {
        public int VisitId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int IllnessId { get; set; }
        public string IllnessName { get; set; }
    }
}
