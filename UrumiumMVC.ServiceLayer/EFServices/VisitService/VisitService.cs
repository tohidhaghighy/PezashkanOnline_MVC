using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.Common.Massage;
using UrumiumMVC.Common.TimeConverter;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.DomainClasses.Entities.Illness;
using UrumiumMVC.DomainClasses.Entities.Visit;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;
using UrumiumMVC.ViewModel.EntityViewModel.AccountingViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.VisitViewModel;

namespace UrumiumMVC.ServiceLayer.EFServices.VisitService
{
    public class VisitService:IVisitService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<VisitTime> _VisitTime;
        private readonly IDbSet<DoctorDays> _DoctorDays;
        private readonly IDbSet<Doctor> _Doctor;
        private readonly IDbSet<Illness> _Illness;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;
        Converter cv = new Converter();
        private ImgSrc imgsrcs;

        #endregion
        public VisitService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _VisitTime = _unitOfWork.Set<VisitTime>();
            _DoctorDays = _unitOfWork.Set<DoctorDays>();
            _Doctor = _unitOfWork.Set<Doctor>();
            _Illness = _unitOfWork.Set<Illness>();
        }

        public async Task<bool> AddVisitTime(int timedaydoctor, int doctorid, int userid,DateTime date)
        {
            try
            {
                var findtimedaydoctorCount =await _VisitTime.Where(a => a.TimeDayDoctor == timedaydoctor).ToListAsync();
                var finddoctor = await _Doctor.FirstOrDefaultAsync(a => a.Id == doctorid);
                int count = findtimedaydoctorCount.Count();
                var codegenerate = GetRandomString(12);
                DateTime dt = DateTime.Now;
                _VisitTime.Add(new VisitTime()
                {
                    Datetime = dt,
                    TimeDayDoctor = timedaydoctor,
                    ReserveDatetime = date,
                    ShowNoskheTo_Pharmacy = false,
                    DoctorId = doctorid,
                    UserId = userid,
                    IsPay = true,
                    IsVisit = false,
                    GiveMedicineFrom_Pharmacy = false,
                    PeigiriCode=codegenerate,
                    Nobat=count+1,
                    Cost=finddoctor.Cost
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool AddVisitTimeWebService(int timedaydoctor, int doctorid, int userid, DateTime date)
        {
            try
            {
                var findtimedaydoctorCount = _VisitTime.Where(a => a.TimeDayDoctor == timedaydoctor).ToList();
                var finddoctor = _Doctor.FirstOrDefault(a => a.Id == doctorid);
                int count = findtimedaydoctorCount.Count();
                var codegenerate = GetRandomString(12);
                DateTime dt = DateTime.Now;
                _VisitTime.Add(new VisitTime()
                {
                    Datetime = dt,
                    TimeDayDoctor = timedaydoctor,
                    ReserveDatetime = date,
                    ShowNoskheTo_Pharmacy = false,
                    DoctorId = doctorid,
                    UserId = userid,
                    IsPay = true,
                    IsVisit = false,
                    GiveMedicineFrom_Pharmacy = false,
                    PeigiriCode = codegenerate,
                    Nobat = count + 1,
                    Cost=finddoctor.Cost
                });
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteVisitTime(int id)
        {
            var find = await _VisitTime.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _VisitTime.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<VisitTime>> GetAllVisitTime()
        {
            return await _VisitTime.ToListAsync();
        }

        public async Task<int> GetDatevisittimecount(int TimeDayDoctor)
        {
            return _VisitTime.Where(a=>a.TimeDayDoctor==TimeDayDoctor).Count();
        }

        public async Task<VisitTime> GetVisitFirst(int id)
        {
            return await _VisitTime.FirstOrDefaultAsync(a=>a.Id==id);
        }

        public async Task<VisitTime> GetVisitPeigiri(string peigiricode)
        {
            return await _VisitTime.FirstOrDefaultAsync(a => a.PeigiriCode==peigiricode);
        }

        public async Task<List<VisitTime>> GetDoctorVisitTime(int doctorid)
        {
            return await _VisitTime.Where(b=>b.DoctorId==doctorid).OrderByDescending(a=>a.Id).ToListAsync();
        }

        public async Task<List<VisitTime>> SendedListNoskheToPharmacy()
        {
            return await _VisitTime.Where(b => b.ShowNoskheTo_Pharmacy == true).OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<List<VisitTime>> GetIllnessVisitTime(int illnessid)
        {
            return await _VisitTime.Where(b => b.UserId == illnessid).OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<List<VisitListViewModel>> GetTodayDoctorVisitTime(int doctorid,DateTime date)
        {
            DateTime changedata = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            List<VisitListViewModel> allvisit = new List<VisitListViewModel>();
            var finddatetimeitem = await _DoctorDays.FirstOrDefaultAsync(a => a.ReserveEnglishDatetime.Equals(changedata) && a.DoctorId==doctorid);
            if (finddatetimeitem!=null)
            {
                var findallinfo = await _VisitTime.Where(a => a.TimeDayDoctor == finddatetimeitem.Id && a.DoctorId == doctorid).ToListAsync();
                foreach (var item in findallinfo)
                {
                    var findillnes = await _Illness.FirstOrDefaultAsync(a => a.Id == item.UserId);
                    VisitListViewModel newvisit = new VisitListViewModel()
                    {
                        DoctorName=item.DayTimes.Doctors.Name,
                        DoctorId=item.DoctorId,
                        IllnessId=item.UserId,
                        Is_Pay=item.IsPay,
                        Is_Visit_Finish=item.IsVisit,
                        Id=item.Id,
                        ReserveTime=item.DayTimes.ReservePersianDatetime,
                        IllnessName=findillnes.Name,
                        Code=item.PeigiriCode
                    };
                    allvisit.Add(newvisit);
                }
                return allvisit;
            }
            return null;
        }


        public async Task<List<VisitListViewModel>> GetSearchDateDoctorVisitTime(int doctorid, string date)
        {
            DateTime ds = cv.ConvertToEnglishSearchDatetime(date);
            List<VisitListViewModel> allvisit = new List<VisitListViewModel>();
            var finddatetimeitem = await _DoctorDays.FirstOrDefaultAsync(a => a.ReserveEnglishDatetime.Equals(ds) && a.DoctorId == doctorid);
            if (finddatetimeitem != null)
            {
                var findallinfo = await _VisitTime.Where(a => a.TimeDayDoctor == finddatetimeitem.Id && a.DoctorId == doctorid).ToListAsync();
                foreach (var item in findallinfo)
                {
                    var findillnes = await _Illness.FirstOrDefaultAsync(a => a.Id == item.UserId);
                    VisitListViewModel newvisit = new VisitListViewModel()
                    {
                        DoctorName = item.DayTimes.Doctors.Name,
                        DoctorId = item.DoctorId,
                        IllnessId = item.UserId,
                        Is_Pay = item.IsPay,
                        Is_Visit_Finish = item.IsVisit,
                        Id = item.Id,
                        ReserveTime = item.DayTimes.ReservePersianDatetime,
                        IllnessName = findillnes.Name,
                        Code=item.PeigiriCode
                    };
                    allvisit.Add(newvisit);
                }
                return allvisit;
            }
            return null;
        }

        public async Task<List<VisitTime>> GetTodayUserVisitTime(int userid, DateTime date)
        {
           return await _VisitTime.Where(a =>a.UserId==userid && a.DayTimes.ReserveEnglishDatetime>=date).ToListAsync();
        }

        public async Task<List<VisitTime>> GetAllUserVisitTime(int userid)
        {
            return await _VisitTime.Where(a => a.UserId == userid).OrderByDescending(b=>b.Id).ToListAsync();
        }

        public async Task<List<VisitTime>> GetParvandeIllness(int doctorid,int illnessid)
        {
            return await _VisitTime.Where(a => a.UserId == illnessid && a.DoctorId==doctorid).OrderByDescending(b => b.Id).ToListAsync();
        }

        public async Task<bool> ShowNoskheToPharmacy(int visitid)
        {
            var find = await _VisitTime.FirstOrDefaultAsync(a => a.Id == visitid);
            if (find != null)
            {
                find.ShowNoskheTo_Pharmacy = true;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DontShowNoskheToPharmacy(int visitid)
        {
            var find = await _VisitTime.FirstOrDefaultAsync(a => a.Id == visitid);
            if (find != null)
            {
                find.ShowNoskheTo_Pharmacy = false;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> GiveMedicineFromPharmacy(int visitid)
        {
            var find = await _VisitTime.FirstOrDefaultAsync(a => a.Id == visitid);
            if (find != null)
            {
                find.GiveMedicineFrom_Pharmacy = true;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> FinishVisit(int visitid)
        {
            var find = await _VisitTime.FirstOrDefaultAsync(a => a.Id == visitid);
            if (find != null)
            {
                find.IsVisit = true;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
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



        // web service android 

        public async Task<List<VisitWebService>> GetAllUserVisitTimeWebservice(int userid)
        {
            List<VisitWebService> allvisit = new List<VisitWebService>();
            var find= await _VisitTime.Where(a => a.UserId == userid).OrderByDescending(b => b.Id).ToListAsync();
            foreach (var item in find)
            {
                VisitWebService newvisitwebservice = new VisitWebService()
                {
                    Datetime=item.Datetime,
                    DoctorId=item.DoctorId,
                    Id=item.Id,
                    IsVisit=item.IsVisit,
                    Nobat=item.Nobat,
                    Doctorname=item.DayTimes.Doctors.Name,
                    ReserveDatetime=item.DayTimes.ReservePersianDatetime,
                    TimeDayDoctorDes=item.DayTimes.TimeVisit
                };
                allvisit.Add(newvisitwebservice);
            }
            return allvisit;
        }

        public async Task<List<VisitWebService>> GetAllUserVisitTimeWebservice(int doctorid, DateTime date)
        {
            DateTime changedata = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            List<VisitWebService> allvisit = new List<VisitWebService>();
            var find = await _VisitTime.Where(a => a.DoctorId == doctorid && a.ReserveDatetime.Equals(changedata)).OrderByDescending(b => b.Id).ToListAsync();
            foreach (var item in find)
            {
                var findillness = await _Illness.FirstOrDefaultAsync(a => a.Id == item.UserId);
                if (findillness != null)
                {
                    VisitWebService newvisitwebservice = new VisitWebService()
                    {
                        Datetime = item.Datetime,
                        DoctorId = item.DoctorId,
                        Id = item.Id,
                        IsVisit = item.IsVisit,
                        Nobat = item.Nobat,
                        Doctorname = "",
                        ReserveDatetime = item.DayTimes.ReservePersianDatetime,
                        TimeDayDoctorDes = item.DayTimes.TimeVisit,
                        Illnessname = findillness.Name,
                        PeigiriCode = item.PeigiriCode
                    };
                    allvisit.Add(newvisitwebservice);
                }

            }
            return allvisit;
        }

        public async Task<List<VisitWebService>> GetAlldoctorVisitTimeWebservice(int doctorid)
        {
           
            List<VisitWebService> allvisit = new List<VisitWebService>();
            var find = await _VisitTime.Where(a => a.DoctorId == doctorid).OrderByDescending(b => b.Id).ToListAsync();
            foreach (var item in find)
            {
                var findillness = await _Illness.FirstOrDefaultAsync(a => a.Id == item.UserId);
                if (findillness != null)
                {
                    VisitWebService newvisitwebservice = new VisitWebService()
                    {
                        Datetime = item.Datetime,
                        DoctorId = item.DoctorId,
                        Id = item.Id,
                        IsVisit = item.IsVisit,
                        Nobat = item.Nobat,
                        Doctorname = "",
                        ReserveDatetime = item.DayTimes.ReservePersianDatetime,
                        TimeDayDoctorDes = item.DayTimes.TimeVisit,
                        Illnessname = findillness.Name,
                        IllnessId=findillness.Id,
                        PeigiriCode = item.PeigiriCode
                    };
                    allvisit.Add(newvisitwebservice);
                }

            }
            return allvisit;
        }

        public async Task<List<AccountingViewModel>> Getallvisittimelist(DateTime start,DateTime finish)
        {

            List<AccountingViewModel> allvisit = new List<AccountingViewModel>();
            var find = await _VisitTime.Where(a => a.ReserveDatetime>=start && a.ReserveDatetime<=finish).OrderByDescending(b => b.Id).ToListAsync();
            foreach (var item in find)
            {
                var findillness = await _Illness.FirstOrDefaultAsync(a => a.Id == item.UserId);
                var finddoctor = await _Doctor.FirstOrDefaultAsync(a => a.Id == item.DoctorId);
                if (findillness != null)
                {
                    AccountingViewModel newvisitwebservice = new AccountingViewModel()
                    {
                        Id = item.Id,
                        Cost = item.Cost.ToString(),
                        Dateandtime=item.ReserveDatetime.ToString(),
                        DoctorName=finddoctor.Name,
                        IllnessName=findillness.Name,
                        PeigiriCode = item.PeigiriCode
                    };
                    allvisit.Add(newvisitwebservice);
                }

            }
            return allvisit;
        }

        public async Task<NoskheInfoWebService> ShowNoskheinfoWebService(int visitid)
        {
            NoskheInfoWebService newinfo = new NoskheInfoWebService();
            var find = await _VisitTime.FirstOrDefaultAsync(a => a.Id == visitid);
            if (find != null)
            {
                var finddoctor = await _Doctor.FirstOrDefaultAsync(a => a.Id == find.DoctorId);
                var findillness = await _Illness.FirstOrDefaultAsync(a => a.Id == find.UserId);
                if (finddoctor != null && findillness != null)
                {
                    newinfo.Id = find.Id;
                    newinfo.Illnessname = findillness.Name;
                    newinfo.Doctorname = finddoctor.Name;
                    if (findillness.Image == "" || findillness.Image==null)
                    {
                        newinfo.Illnessimage = ImgSrc.MainUrl + ImgSrc.ImgeDefaultUrl;
                    }
                    else
                    {
                        newinfo.Illnessimage = ImgSrc.MainUrl + ImgSrc.IllnessUrl + findillness.Image;
                    }
                    if (finddoctor.Image == "" || finddoctor.Image ==null)
                    {
                        newinfo.Doctorimage = ImgSrc.MainUrl + ImgSrc.ImgeDefaultUrl;
                    }
                    else
                    {
                        newinfo.Doctorimage = ImgSrc.MainUrl + ImgSrc.DoctorUrl + finddoctor.Image;
                    }
                    
                    newinfo.TypeBime = findillness.Insurances.Name;
                    newinfo.CodeBime = findillness.InsuranceSerial;
                    newinfo.DoctorNezamPezeshki = finddoctor.NezamPezeshkiCode;
                    newinfo.PeigiriCode = find.PeigiriCode;
                    newinfo.Datevisit = find.ReserveDatetime.ToShortDateString();
                }
                
            }
            return newinfo;
        }
    }
}
