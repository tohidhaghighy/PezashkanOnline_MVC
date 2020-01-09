using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Visit;

namespace UrumiumMVC.DomainClasses.Entities.Doctor
{
    public class DoctorDays
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int DayId { get; set; }
        public string TimeVisit { get; set; }
        public int CountVisit { get; set; }
        public DateTime ReserveEnglishDatetime { get; set; }
        public string ReservePersianDatetime { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public virtual Doctor Doctors { get; set; }

        public virtual ICollection<VisitTime> VisitTimes { get; set; }
    }
}
