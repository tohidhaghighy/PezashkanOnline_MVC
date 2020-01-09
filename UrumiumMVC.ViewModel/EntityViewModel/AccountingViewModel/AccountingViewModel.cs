using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.AccountingViewModel
{
    public class AccountingViewModel
    {
        public int Id { get; set; }
        public string PeigiriCode { get; set; }
        public string Dateandtime { get; set; }
        public string DoctorName { get; set; }
        public string IllnessName { get; set; }
        public string Cost { get; set; }
    }
}
