using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.Common.TimeConverter;

namespace UrumiumMVC.DomainClasses.Entities.Pharmacy
{
    public class Illness_Pharmacy_Massage
    {
        public Illness_Pharmacy_Massage()
        {
            this.Time = DateTime.Now;
            this.Exist_Noskhe = false;
            this.Answer = "";
        }
        public int Id { get; set; }
        public int IllnessId { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string Answer { get; set; }
        public DateTime Time { get; set; }
        public Boolean Exist_Noskhe { get; set; }
    }
}
