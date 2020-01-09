using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Insurance
{
    public class InsuranceDoctor
    {
        public int Id { get; set; }
        public int InsuranceId { get; set; }
        public int DoctorId { get; set; }

        [ForeignKey(nameof(InsuranceId))]
        public virtual Insurance Insurances { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public virtual Doctor.Doctor Doctors { get; set; }
    }
}
