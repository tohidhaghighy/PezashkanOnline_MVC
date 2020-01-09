using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Pharmacy
{
    public class Pharmacy_Massage
    {
        public int Id { get; set; }
        public int IllnessId { get; set; }
        public int DoctorId { get; set; }
        public int VisitId { get; set; }
        public int PharmacyId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfDescription { get; set; }
        [ForeignKey(nameof(PharmacyId))]
        public virtual Pharmacy Pharmacies { get; set; }
    }
}
