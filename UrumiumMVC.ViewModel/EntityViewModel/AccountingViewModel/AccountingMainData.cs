using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.AccountingViewModel
{
    public class AccountingMainData
    {
        public int Id { get; set; }
        public string VisitCount { get; set; }
        public string VisitCost { get; set; }
        public List<AccountingViewModel> VisitList { get; set; }
    }
}
