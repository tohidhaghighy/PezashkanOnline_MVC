using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Question;
using UrumiumMVC.ServiceLayer.Contract.AnswerQuestionInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.AnswerQuestionService
{
    public class AnswerQuestionService:IAnswerQuestionService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<UserAnswerToQuestion> _UserAnswerToQuestion;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public AnswerQuestionService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _UserAnswerToQuestion = _unitOfWork.Set<UserAnswerToQuestion>();
        }


        public async Task<bool> AddUserAnswerToQuestion(int IllnessId,int QuestionId, string Text)
        {
            try
            {
                _UserAnswerToQuestion.Add(new UserAnswerToQuestion()
                {
                    IllnessId=IllnessId,
                    AnswerText=Text,
                    QuestionId=QuestionId
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUserAnswerToQuestion(int IllnessId, int QuestionId, string Text)
        {
            var findquestion = await _UserAnswerToQuestion.FirstOrDefaultAsync(a => a.QuestionId == QuestionId && a.IllnessId == IllnessId);
            _UserAnswerToQuestion.Remove(findquestion);
            await _unitOfWork.SaveChangesAsync();

            try
            {
                _UserAnswerToQuestion.Add(new UserAnswerToQuestion()
                {
                    IllnessId = IllnessId,
                    AnswerText = Text,
                    QuestionId = QuestionId
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAnswerToQuestion(int id)
        {
            var find = await _UserAnswerToQuestion.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _UserAnswerToQuestion.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<UserAnswerToQuestion>> GetUserAnswerToQuestion(int IllnessId)
        {
            return await _UserAnswerToQuestion.Where(a => a.IllnessId == IllnessId).ToListAsync();
        }

        public async Task<bool> UpdateUserAnswerToQuestion(int Id, string Text)
        {
            try
            {
                var finditem = await _UserAnswerToQuestion.FirstOrDefaultAsync(a => a.Id == Id);
                if (finditem != null)
                {
                    finditem.AnswerText = Text;
                }
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}
