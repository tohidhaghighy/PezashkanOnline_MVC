using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Question;
using UrumiumMVC.DomainClasses.Entities.Visit;

namespace UrumiumMVC.DomainClasses.Entities.Illness
{
    public class Illness
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int PressureBlood { get; set; }
        public int Sugar { get; set; }
        public int InsuranceId { get; set; }
        public string InsuranceSerial { get; set; }
        public string InsuranceFinishDate { get; set; }
        public int CityId { get; set; }
        public string Image { get; set; }
        public string ImageBimeFirstPage { get; set; }
        public Boolean Active { get; set; }
        public string Userid { get; set; }
        public string Mobile { get; set; }
        public string CodeActiveUse { get; set; }
        public Boolean Is_Use_CodeValue { get; set; }
        public string Password { get; set; }

        //foregn key

        [ForeignKey(nameof(CityId))]
        public virtual Common.City Cities { get; set; }

        [ForeignKey(nameof(InsuranceId))]
        public virtual Insurance.Insurance Insurances { get; set; }


        public virtual ICollection<UserAnswerToQuestion> UserAnswerToQuestions { get; set; }
        public virtual ICollection<judge.JudgeIllnessPayment> JudgeIllnessPayments { get; set; }
    }
}
