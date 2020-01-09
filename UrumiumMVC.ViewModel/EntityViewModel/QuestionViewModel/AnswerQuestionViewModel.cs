using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Question;

namespace UrumiumMVC.ViewModel.EntityViewModel.QuestionViewModel
{
    public class AnswerQuestionViewModel
    {
        public int Id { get; set; }
        public int IllnessId { get; set; }
        public int DoctorId { get; set; }
        public int VisitId { get; set; }
        public List<UserAnswerToQuestion> UserAnswerToQuestionList { get; set; }
    }
}
