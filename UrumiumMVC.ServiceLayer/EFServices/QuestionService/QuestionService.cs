using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Question;
using UrumiumMVC.ServiceLayer.Contract.QuestionInterface;
using UrumiumMVC.ViewModel.EntityViewModel.QuestionViewModel;

namespace UrumiumMVC.ServiceLayer.EFServices.QuestionService
{
    public class QuestionService:IQuestionService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Question> _Question;
        private readonly IDbSet<UserAnswerToQuestion> _UserAnswerToQuestion;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public QuestionService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Question = _unitOfWork.Set<Question>();
            _UserAnswerToQuestion = _unitOfWork.Set<UserAnswerToQuestion>();
        }


        public async Task<bool> AddQuestion(int DoctorId, string Text)
        {
            try
            {
                _Question.Add(new Question()
                {
                    DoctorId=DoctorId,
                    Text=Text
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            var find = await _Question.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _Question.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Question>> GetDoctorQuestion(int Doctorid)
        {
            return await _Question.Where(a=>a.DoctorId==Doctorid).ToListAsync();
        }

        public async Task<List<QuestionDoctorWebService>> GetDoctorQuestionWebService(int Doctorid)
        {
            List<QuestionDoctorWebService> allquestion = new List<QuestionDoctorWebService>();
            var find= await _Question.Where(a => a.DoctorId == Doctorid).ToListAsync();
            foreach (var item in find)
            {
                QuestionDoctorWebService quesiton = new QuestionDoctorWebService();
                quesiton.Id = item.Id;
                quesiton.DoctorId = item.DoctorId;
                quesiton.Text = item.Text;
                allquestion.Add(quesiton);
            }
            return allquestion;
        }

        public async Task<List<QuestionViewModel>> GetIllnessQuestion(int Doctorid,int illnessid)
        {
            List<QuestionViewModel> allquestions = new List<QuestionViewModel>();
            var finddoctorquestions=await _Question.Where(a => a.DoctorId == Doctorid).ToListAsync();
            if (finddoctorquestions!=null)
            {
                foreach (var item in finddoctorquestions)
                {
                    QuestionViewModel newquestion = new QuestionViewModel();
                    var findanswer = await _UserAnswerToQuestion.FirstOrDefaultAsync(a => a.IllnessId == illnessid && a.QuestionId == item.Id);
                    if (findanswer!=null)
                    {
                        newquestion.Id = item.Id;
                        newquestion.Answer = findanswer.AnswerText;
                        newquestion.Have_Answer = true;
                        newquestion.Text = item.Text;
                        newquestion.AnswerId = findanswer.Id;
                        allquestions.Add(newquestion);
                    }
                    else
                    {
                        newquestion.Id = item.Id;
                        newquestion.Answer = "";
                        newquestion.Text = item.Text;
                        newquestion.Have_Answer = false;
                        allquestions.Add(newquestion);
                    }
                }
            }
            return allquestions;
        }

        public async Task<bool> UpdateQuestion(int QuestionId,string Text)
        {
            try
            {
                var finditem = await _Question.FirstOrDefaultAsync(a => a.Id == QuestionId);
                if (finditem!=null)
                {
                    finditem.Text = Text;
                }
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Question>> SearchQuestion(string text)
        {
            return await _Question.Where(a => a.Text.Contains(text)).ToListAsync();
        }
    }
}
