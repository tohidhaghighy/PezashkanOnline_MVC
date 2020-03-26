using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.PharmacyMassage
{
    public class PharmacyIllnessMassage
    {
        public int Id { get; set; }
        public int IllnessId { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string Answer { get; set; }
        public string Time { get; set; }
    }
}
