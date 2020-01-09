using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Insurance;
using UrumiumMVC.DomainClasses.Entities.Visit;

namespace UrumiumMVC.DomainClasses.Entities.Doctor
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
        public int CityId { get; set; }
        public string Image { get; set; }
        public DateTime StartTime { get; set; }
        public int ViewerCount { get; set; }
        public Boolean Active { get; set; }
        public Boolean SpecialDoctor { get; set; }
        public int Cost { get; set; }
        public int VerifyKey { get; set; }
        public int IllnessCountVisit { get; set; }
        public string Userid { get; set; }
        public string BusinessKey { get; set; }
        public int MoarefDoctorId { get; set; }
        public string NezamPezeshkiCode { get; set; }
        public string ScanMelliCode { get; set; }
        public string ScanNezamPezeshki { get; set; }
        public string ScanShenasname { get; set; }
        public string Mobile { get; set; }
        public string CodeActiveUse { get; set; }
        public Boolean Is_Use_CodeValue { get; set; }
        public string Password { get; set; }
        public string AccountNumber { get; set; }
        //foregin key

        [ForeignKey(nameof(GroupId))]
        public virtual Group.Group Groups { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual Common.City Cities { get; set; }


        //list of items
        public virtual ICollection<InsuranceDoctor> InsuranceDoctors { get; set; }
        public virtual ICollection<DoctorDays> DoctorDays { get; set; }
        

    }
}
