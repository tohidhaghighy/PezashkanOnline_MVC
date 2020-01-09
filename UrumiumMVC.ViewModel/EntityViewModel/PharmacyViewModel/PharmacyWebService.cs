using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.PharmacyViewModel
{
    public class PharmacyWebService
    {
        public int Id { get; set; }
        public int IllnessId { get; set; }
        public string Pharmacyname { get; set; }
        public int Doctorid { get; set; }
        public int VisitId { get; set; }
        public int PharmacyId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfDescription { get; set; }
    }
}
