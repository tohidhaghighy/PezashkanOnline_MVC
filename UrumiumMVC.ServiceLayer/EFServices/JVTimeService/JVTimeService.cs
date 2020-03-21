using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.judge;
using UrumiumMVC.DomainClasses.Entities.Visit;
using UrumiumMVC.ServiceLayer.Contract.JVTimeInterface;
using UrumiumMVC.ViewModel.EntityViewModel.AccountingViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.JudgeViewModel;

namespace UrumiumMVC.ServiceLayer.EFServices.JVTimeService
{
    public class JVTimeService:IJVTimeService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<JudgeIllnessPayment> _JudgeIllnessPayment;
        private readonly IDbSet<judge> _Judge;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public JVTimeService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _JudgeIllnessPayment = _unitOfWork.Set<JudgeIllnessPayment>();
            _Judge = _unitOfWork.Set<judge>();
        }

        public async Task<bool> AddJudgeIllnessPayment(int illnessid,int cost,string transid)
        {
            try
            {
                string s = GetRandomString(12);
                _JudgeIllnessPayment.Add(new JudgeIllnessPayment()
                {
                    PayDatetime=DateTime.Now,
                    IllnessId=illnessid,
                    FinishAnswer=false,
                    Cost=cost,
                    Peigiricode=s,
                    TransId=transid
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<JudgeIllnessPayment>> GetAllVisitJudgeTime()
        {
            return await _JudgeIllnessPayment.OrderByDescending(a => a.Id).ToListAsync();
        }

        public int GetAlljudgeCount()
        {
            return _JudgeIllnessPayment.OrderByDescending(a => a.Id).Count();
        }
        
        public async Task<List<JudgeIllnessPayment>> GetVisitJudgeList(int id)
        {
            return await _JudgeIllnessPayment.Where(a => a.IllnessId == id).ToListAsync();
        }

        public async Task<List<JudgeIllnessPayment>> GetVisitJudgeOnlyFalseList()
        {
            return await _JudgeIllnessPayment.Where(a => a.FinishAnswer == false).ToListAsync();
        }


        public async Task<bool> ChangeVisitJudgeToFalse(int id)
        {
            var find= await _JudgeIllnessPayment.FirstOrDefaultAsync(a => a.Id == id);
            if (find!=null)
            {
                find.FinishAnswer = true;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }


        //web service android 
        public async Task<List<JudgeIllnessVisitWebService>> GetVisitJudgeListWebservice(int id)
        {
            List<JudgeIllnessVisitWebService> _illnessvisit = new List<JudgeIllnessVisitWebService>();
            var find= await _JudgeIllnessPayment.Where(a => a.IllnessId == id).ToListAsync();
            foreach (var item in find)
            {
                JudgeIllnessVisitWebService newjudgeillnessvisit = new JudgeIllnessVisitWebService()
                {
                    Cost=item.Cost,
                    FinishAnswer=item.FinishAnswer,
                    Id=item.Id,
                    IllnessId=item.IllnessId,
                    Illnessname=item.Illnesses.Name,
                    PayDatetime=item.PayDatetime
                };
                _illnessvisit.Add(newjudgeillnessvisit);
            }
            return _illnessvisit;
        }

        public async Task<List<JudgeIllnessVisitWebService>> GetAllVisitJudgeListWebservice()
        {
            List<JudgeIllnessVisitWebService> _illnessvisit = new List<JudgeIllnessVisitWebService>();
            var find = await _JudgeIllnessPayment.Where(a => a.FinishAnswer==false).OrderByDescending(a=>a.Id).ToListAsync();
            foreach (var item in find)
            {
                JudgeIllnessVisitWebService newjudgeillnessvisit = new JudgeIllnessVisitWebService()
                {
                    Cost = item.Cost,
                    FinishAnswer = item.FinishAnswer,
                    Id = item.Id,
                    IllnessId = item.IllnessId,
                    Illnessname = item.Illnesses.Name,
                    PayDatetime = item.PayDatetime
                };
                _illnessvisit.Add(newjudgeillnessvisit);
            }
            return _illnessvisit;
        }

        public async Task<List<AccountingViewModel>> GetAllJudgetimeforaccounting(DateTime start,DateTime finish)
        {
            List<AccountingViewModel> _judgelist = new List<AccountingViewModel>();
            var find = await _JudgeIllnessPayment.Where(a => a.PayDatetime>=start && a.PayDatetime<=finish).OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in find)
            {
                AccountingViewModel newjudgeillnessvisit = new AccountingViewModel()
                {
                    Cost = item.Cost.ToString(),
                    Id = item.Id,
                    IllnessName = item.Illnesses.Name,
                    DoctorName = "کارشناس",
                    PeigiriCode = item.Peigiricode,
                    Dateandtime=item.PayDatetime.ToString()
                };
                _judgelist.Add(newjudgeillnessvisit);
            }
            return _judgelist;
        }

        public async Task<List<JudgeIllnessVisitWebService>> GetOneUserVisitJudgeListWebservice(int illnessid)
        {
            List<JudgeIllnessVisitWebService> _illnessvisit = new List<JudgeIllnessVisitWebService>();
            var find = await _JudgeIllnessPayment.Where(a => a.IllnessId==illnessid).OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in find)
            {
                JudgeIllnessVisitWebService newjudgeillnessvisit = new JudgeIllnessVisitWebService()
                {
                    Cost = item.Cost,
                    FinishAnswer = item.FinishAnswer,
                    Id = item.Id,
                    IllnessId = item.IllnessId,
                    Illnessname = item.Illnesses.Name,
                    PayDatetime = item.PayDatetime
                };
                _illnessvisit.Add(newjudgeillnessvisit);
            }
            return _illnessvisit;
        }

        Random rand = new Random();
        public string GetRandomString(int length)
        {
            string s = "";
            for (int i = 0; i < length; i++)
                s += rand.Next(0, 10);
            s += "/";
            for (int i = 0; i < 3; i++)
                s += rand.Next(0, 10);
            return s;
        }
    }
}
