using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Visit
{
    public class VisitTime
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public int TimeDayDoctor { get; set; }
        public Boolean IsPay { get; set; }
        public Boolean IsVisit { get; set; }
        public Boolean ShowNoskheTo_Pharmacy { get; set; }
        public Boolean GiveMedicineFrom_Pharmacy { get; set; }
        public DateTime Datetime { get; set; }
        public DateTime ReserveDatetime { get; set; }
        public string PeigiriCode { get; set; }
        public int Nobat { get; set; }
        public int Cost { get; set; }
        public string TransId { get; set; }


        [ForeignKey(nameof(TimeDayDoctor))]
        public virtual Doctor.DoctorDays DayTimes { get; set; }
        
    }
}
