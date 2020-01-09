using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Question
{
    public class UserAnswerToQuestion
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int IllnessId { get; set; }
        public string AnswerText { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public virtual Question Questions { get; set; }
        [ForeignKey(nameof(IllnessId))]
        public virtual Illness.Illness Illnesses { get; set; }

    }
}
