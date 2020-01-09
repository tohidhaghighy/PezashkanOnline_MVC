using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.AnswerQuestionInterface;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.QuestionInterface;
using UrumiumMVC.ViewModel.EntityViewModel.QuestionViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class QuestionController : Controller
    {
        IQuestionService _questionservices;
        IAnswerQuestionService _answerquestionservices;
        IDoctorService _doctorservice;
        IIllnessService _illnessservice;
        readonly IUnitOfWork _uow;
        public QuestionController(IAnswerQuestionService answerquestionservices, IQuestionService questionservices, IDoctorService doctorservice,IIllnessService illnessservice,
            IUnitOfWork uow)
        {
            _answerquestionservices = answerquestionservices;
            _questionservices = questionservices;
            _doctorservice = doctorservice;
            _illnessservice = illnessservice;
            _uow = uow;
        }
        // GET: Question
        public async virtual Task<ActionResult> DoctorQuestion(string id)
        {
            var finddoctor = await _doctorservice.GetDoctorwithguidid(id);
            if (finddoctor != null)
            {
                return View(await _questionservices.GetDoctorQuestion(finddoctor.Id));
            }
            return View("/DoctorQuestion?id=" + id);
        }

        [HttpPost]
        public async virtual Task<Boolean> AddQuestion(string id, string text)
        {
            var finddoctor = await _doctorservice.GetDoctorwithguidid(id);
            if (finddoctor != null)
            {
                await _questionservices.AddQuestion(finddoctor.Id, text);
                return true;
            }
            return false;
        }

        public async virtual Task<ActionResult> IllnessAnswerQuestion(int illnessid,int visitid,int doctorid)
        {
            QuestionListInfoViewModel newquestion = new QuestionListInfoViewModel();
            newquestion.DoctorId = doctorid;
            newquestion.IllnessId = illnessid;
            newquestion.VisitId = visitid;
            newquestion.QuestionViewModelList = await _questionservices.GetIllnessQuestion(doctorid, illnessid);
            return View(newquestion);
        }


        public async virtual Task<ActionResult> DoctorShowIllnessAnswerQuestion(int illnessid, int visitid, int doctorid)
        {
            AnswerQuestionViewModel newquestion = new AnswerQuestionViewModel();
            newquestion.DoctorId = doctorid;
            newquestion.IllnessId = illnessid;
            newquestion.VisitId = visitid;
            newquestion.UserAnswerToQuestionList = await _answerquestionservices.GetUserAnswerToQuestion(illnessid);
            return View(newquestion);
        }

        public async virtual Task<Boolean> UpdateQuestion(int id, string text = "")
        {

            if (text != null && text != "")
            {
                await _questionservices.UpdateQuestion(id, text);
            }
            return true;
        }

        public async virtual Task<Boolean> DeleteQuestion(int id = 0)
        {

            if (id != 0)
            {
                await _questionservices.DeleteQuestion(id);
            }
            return true;
        }

        public async virtual Task<ActionResult> AddAnswerQuestion(string text,string userid,int questionid)
        {
            var finduser = await _illnessservice.Getillness(userid);
            if (finduser!=null)
            {
                if (await _answerquestionservices.AddUserAnswerToQuestion(finduser.Id,questionid,text))
                {
                    return new JsonNetResult
                    {
                        Data = new
                        {
                            success = true
                        }
                    };
                }
                
            }
            return new JsonNetResult
            {
                Data = new
                {
                    success = false
                }
            };
        }

        public async virtual Task<ActionResult> UpdateAnswerQuestion(int id,string text)
        {
            
                if (await _answerquestionservices.UpdateUserAnswerToQuestion(id, text))
                {
                    return new JsonNetResult
                    {
                        Data = new
                        {
                            success = true
                        }
                    };
                }
            return new JsonNetResult
            {
                Data = new
                {
                    success = false
                }
            };
        }
    }
}