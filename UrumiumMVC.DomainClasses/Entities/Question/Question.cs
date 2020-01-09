using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Question
{
    public class Question
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Text { get; set; }
        public virtual ICollection<UserAnswerToQuestion> UserAnswerToQuestions { get; set; }
    }
}
