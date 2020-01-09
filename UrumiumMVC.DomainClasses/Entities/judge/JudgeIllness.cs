using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.judge
{
    public class JudgeIllness
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string OnlyUrlText { get; set; }
        //User=true  judge = false
        public Boolean UserJudge { get; set; }
        public String AnswerUserId { get; set; }
        public DateTime AnswerDatetime { get; set; }
        public int JudgeIllnessPaymentId { get; set; }
        public int TypeMassage { get; set; }
    }
}
