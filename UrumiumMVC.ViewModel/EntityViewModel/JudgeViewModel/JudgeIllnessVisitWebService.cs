using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.JudgeViewModel
{
    public class JudgeIllnessVisitWebService
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public DateTime PayDatetime { get; set; }
        public int IllnessId { get; set; }
        public string Illnessname { get; set; }
        public Boolean FinishAnswer { get; set; }
    }
}
