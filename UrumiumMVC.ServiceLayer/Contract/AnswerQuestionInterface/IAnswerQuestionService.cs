using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Question;

namespace UrumiumMVC.ServiceLayer.Contract.AnswerQuestionInterface
{
    public interface IAnswerQuestionService
    {
        Task<bool> AddUserAnswerToQuestion(int IllnessId, int QuestionId, string Text);
        Task<bool> DeleteUserAnswerToQuestion(int id);
        Task<List<UserAnswerToQuestion>> GetUserAnswerToQuestion(int IllnessId);
        Task<bool> UpdateUserAnswerToQuestion(int Id, string Text);


        // web service 

        Task<bool> UpdateUserAnswerToQuestion(int IllnessId, int QuestionId, string Text);
    }
}
