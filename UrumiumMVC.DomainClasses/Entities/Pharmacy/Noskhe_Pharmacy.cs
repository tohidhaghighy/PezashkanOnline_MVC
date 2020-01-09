using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Pharmacy
{
    public class Noskhe_Pharmacy
    {
        public int Id { get; set; }
        public int IllnessId { get; set; }
        public int DoctorId { get; set; }
        public int VisitId { get; set; }
        public int PharmacyId { get; set; }
        public Boolean Is_Exist { get; set; }
        public string Description { get; set; }

    }
}
