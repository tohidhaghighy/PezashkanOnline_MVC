using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.judge
{
    public class JudgeIllnessPayment
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public DateTime PayDatetime { get; set; }
        public int IllnessId { get; set; }
        public string Peigiricode { get; set; }
        public Boolean FinishAnswer { get; set; }
        public string TransId { get; set; }

        [ForeignKey(nameof(IllnessId))]
        public virtual Illness.Illness Illnesses { get; set; }
    }
}
