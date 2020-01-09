using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.IllnessViewModel
{
    public class IllnessWebService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int PressureBlood { get; set; }
        public int Sugar { get; set; }
        public int InsuranceId { get; set; }
        public string InsuranceSerial { get; set; }
        public string InsuranceFinishDate { get; set; }
        public string Image { get; set; }
        public string Userid { get; set; }

    }
}
