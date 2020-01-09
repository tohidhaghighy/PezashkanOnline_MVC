using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.VisitViewModel
{
    public class VisitWebService
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Doctorname { get; set; }
        public int UserId { get; set; }
        public string Illnessname { get; set; }
        public int IllnessId { get; set; }
        public int TimeDayDoctor { get; set; }
        public string TimeDayDoctorDes { get; set; }
        public Boolean IsPay { get; set; }
        public Boolean IsVisit { get; set; }
        public Boolean ShowNoskheTo_Pharmacy { get; set; }
        public Boolean GiveMedicineFrom_Pharmacy { get; set; }
        public DateTime Datetime { get; set; }
        public string ReserveDatetime { get; set; }
        public string PeigiriCode { get; set; }
        public int Nobat { get; set; }
    }
}
