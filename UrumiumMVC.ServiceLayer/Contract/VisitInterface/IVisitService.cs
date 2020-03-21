using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Visit;
using UrumiumMVC.ViewModel.EntityViewModel.AccountingViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.VisitViewModel;

namespace UrumiumMVC.ServiceLayer.Contract.VisitInterface
{
    public interface IVisitService
    {
        Task<bool> AddVisitTime(int timedaydoctor, int doctorid, int userid, DateTime date,string transid);
        Task<bool> DeleteVisitTime(int id);
        Task<List<VisitTime>> GetAllVisitTime();
        Task<List<VisitListViewModel>> GetTodayDoctorVisitTime(int doctorid, DateTime date);
        Task<List<VisitTime>> GetTodayUserVisitTime(int userid, DateTime date);
        Task<List<VisitTime>> GetDoctorVisitTime(int doctorid);
        Task<List<VisitTime>> GetIllnessVisitTime(int illnessid);
        Task<List<VisitListViewModel>> GetSearchDateDoctorVisitTime(int doctorid, string date);
        Task<List<VisitTime>> GetAllUserVisitTime(int userid);
        Task<bool> ShowNoskheToPharmacy(int visitid);
        Task<List<VisitTime>> SendedListNoskheToPharmacy();
        Task<VisitTime> GetVisitFirst(int id);
        Task<List<VisitTime>> GetParvandeIllness(int doctorid, int illnessid);
        Task<bool> DontShowNoskheToPharmacy(int visitid);
        Task<bool> GiveMedicineFromPharmacy(int visitid);
        Task<bool> FinishVisit(int visitid);
        Task<int> GetDatevisittimecount(int TimeDayDoctor);

        //web service 

        Task<List<VisitWebService>> GetAllUserVisitTimeWebservice(int userid);
        Task<List<VisitWebService>> GetAllUserVisitTimeWebservice(int doctorid, DateTime date);
        Task<List<VisitWebService>> GetAlldoctorVisitTimeWebservice(int doctorid);
        Task<NoskheInfoWebService> ShowNoskheinfoWebService(int visitid);
        bool AddVisitTimeWebService(int timedaydoctor, int doctorid, int userid, DateTime date);


        //accounting function 
        Task<List<AccountingViewModel>> Getallvisittimelist(DateTime start, DateTime finish);
    }
}
