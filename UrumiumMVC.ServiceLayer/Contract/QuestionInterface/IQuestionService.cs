using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Question;
using UrumiumMVC.ViewModel.EntityViewModel.QuestionViewModel;

namespace UrumiumMVC.ServiceLayer.Contract.QuestionInterface
{
    public interface IQuestionService
    {
        Task<bool> AddQuestion(int DoctorId, string Text);
        Task<bool> DeleteQuestion(int id);
        Task<List<Question>> GetDoctorQuestion(int Doctorid);
        Task<bool> UpdateQuestion(int QuestionId, string Text);
        Task<List<Question>> SearchQuestion(string text);
        Task<List<QuestionViewModel>> GetIllnessQuestion(int Doctorid, int illnessid);


        //web service
        Task<List<QuestionDoctorWebService>> GetDoctorQuestionWebService(int Doctorid);
    }
}
