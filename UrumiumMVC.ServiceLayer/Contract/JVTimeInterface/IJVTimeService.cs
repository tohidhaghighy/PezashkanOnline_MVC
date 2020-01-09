using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.judge;
using UrumiumMVC.ViewModel.EntityViewModel.AccountingViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.JudgeViewModel;

namespace UrumiumMVC.ServiceLayer.Contract.JVTimeInterface
{
    public interface IJVTimeService
    {
        Task<bool> AddJudgeIllnessPayment(int illnessid, int cost);
        Task<List<JudgeIllnessPayment>> GetAllVisitJudgeTime();
        int GetAlljudgeCount();
        Task<List<JudgeIllnessPayment>> GetVisitJudgeList(int id);
        Task<List<JudgeIllnessPayment>> GetVisitJudgeOnlyFalseList();
        Task<bool> ChangeVisitJudgeToFalse(int id);


        // web service android 
        Task<List<JudgeIllnessVisitWebService>> GetVisitJudgeListWebservice(int id);
        Task<List<JudgeIllnessVisitWebService>> GetAllVisitJudgeListWebservice();
        Task<List<JudgeIllnessVisitWebService>> GetOneUserVisitJudgeListWebservice(int illnessid);


        Task<List<AccountingViewModel>> GetAllJudgetimeforaccounting(DateTime start, DateTime finish);

    }
}
