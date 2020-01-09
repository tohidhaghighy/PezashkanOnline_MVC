using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Accounting
{
    public class VisitDoctorAccount
    {
        public int Id { get; set; }
        public int VisiteDoctorId { get; set; }
        public int Doctorid { get; set; }
        public int UserId { get; set; }
        public int Cost { get; set; }
        public string PayId { get; set; }
        public DateTime DateofPay { get; set; }
    }
}
