using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageIllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageJudgeInterface;
using UrumiumMVC.ViewModel.EntityViewModel.ChatViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class ChatController : Controller
    {
        IMassageIService _massageillnessservices;
        IMassageJService _massagejudgeservices;
        IIllnessService _illnessservices;
        IDoctorService _doctorservice;
        readonly IUnitOfWork _uow;
        public ChatController(IMassageIService massageillnessservice, IIllnessService illnessservice,IMassageJService massagejudgeservice,IDoctorService doctorservice,
            IUnitOfWork uow)
        {
            _massageillnessservices = massageillnessservice;
            _illnessservices = illnessservice;
            _doctorservice = doctorservice;
            _massagejudgeservices = massagejudgeservice;
            _uow = uow;
        }
        // GET: Chat
        public virtual async Task<ActionResult> Index(int visitid, int illnessid, int doctorid, string name)
        {
            ChatUser chatinfo = new ChatUser();
            chatinfo.doctorid = doctorid;
            chatinfo.illnessid = illnessid;
            chatinfo.Groupname = visitid + "";
            chatinfo.Sendername = name;
          
            chatinfo.Allmassages = await _massageillnessservices.GetAllIllnessMassage(visitid);
            return View(chatinfo);
        }

        public virtual async Task<ActionResult> JudgeChat(int visitid, int illnessid, string name)
        {
            ChatJudgeUser chatinfo = new ChatJudgeUser();
            chatinfo.illnessid = illnessid;
            chatinfo.Groupname = visitid + "";
            chatinfo.Sendername = name;
            
            chatinfo.Allmassages = await _massagejudgeservices.GetAllJudgeIllness(visitid);
            return View(chatinfo);
        }

        public virtual async Task<ActionResult> DoctorChatroom(int visitid, int illnessid, int doctorid, string name)
        {
            ChatUser chatinfo = new ChatUser();
            chatinfo.doctorid = doctorid;
            chatinfo.illnessid = illnessid;
            chatinfo.Groupname = visitid + "";
            chatinfo.Sendername = name;
            var finddoctor = await _doctorservice.GetDoctor(doctorid);
            var findillness = await _illnessservices.GetillnessClient(illnessid);
            chatinfo.doctorname = "";
            chatinfo.illnessname = "";
            if (name=="U")
            {
                chatinfo.UserId = findillness.Userid;
            }
            else if (name=="D")
            {
                chatinfo.UserId = finddoctor.Userid;
            }
            if (finddoctor!=null)
            {
                chatinfo.doctorname = finddoctor.Name;
            }
            if (findillness!=null)
            {
                chatinfo.illnessname = findillness.Name;
            }
            chatinfo.Allmassages = await _massageillnessservices.GetAllIllnessMassage(visitid);
            chatinfo.Allmassages.Reverse();
            return View(chatinfo);
        }

        public virtual async Task<ActionResult> JudgeChatroom(int visitid, int illnessid, string name)
        {
            ChatJudgeUser chatinfo = new ChatJudgeUser();
            chatinfo.illnessid = illnessid;
            chatinfo.Groupname = visitid + "";
            chatinfo.Sendername = name;
            var findillness = await _illnessservices.GetillnessClient(illnessid);
            chatinfo.Illnessname = "";
            if (name == "U")
            {
                chatinfo.UserId = findillness.Userid;
            }
            else if (name == "D")
            {
                chatinfo.UserId = "";
            }
            if (findillness!=null)
            {
                chatinfo.Illnessname = findillness.Name;
            }
            chatinfo.Allmassages = await _massagejudgeservices.GetAllJudgeIllness(visitid);
            chatinfo.Allmassages.Reverse();
            return View(chatinfo);
        }

    }
}