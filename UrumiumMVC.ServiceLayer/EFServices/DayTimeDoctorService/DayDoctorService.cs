using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.Common.TimeConverter;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.ServiceLayer.Contract.DayTimeDoctorInterface;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;

namespace UrumiumMVC.ServiceLayer.EFServices.DayTimeDoctorService
{
    public class DayDoctorService:IDayDoctorService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<DoctorDays> _DoctorDay;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;
        Converter cv = new Converter();
        #endregion
        public DayDoctorService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _DoctorDay = _unitOfWork.Set<DoctorDays>();
        }

        public async Task<bool> AddDayDoctor(int doctorid=0,string date="",string timevisit="",int countuser=0)
        {
            try
            {
                string dtitem = cv.ConvertToPersianCalenderDatetime(date);
                DateTime ds = cv.ConvertToEnglishSearchDatetime(date);
                _DoctorDay.Add(new DoctorDays()
                {
                   CountVisit=countuser,
                   DayId=0,
                   DoctorId=doctorid,
                   TimeVisit=timevisit,
                   ReservePersianDatetime= dtitem,
                   ReserveEnglishDatetime=ds,
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddDayDoctorWebService(int doctorid = 0, string date = "", string timevisit = "", int countuser = 0)
        {
            try
            {
                DateTime ds = cv.ConvertToEnglishSearchDatetimeStartToFinish(date);
                _DoctorDay.Add(new DoctorDays()
                {
                    CountVisit = countuser,
                    DayId = 0,
                    DoctorId = doctorid,
                    TimeVisit = timevisit,
                    ReservePersianDatetime = date,
                    ReserveEnglishDatetime = ds,
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteDoctorDays(int id)
        {
            var find = await _DoctorDay.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _DoctorDay.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<DoctorDays>> GetAllDoctorDays(int doctorid)
        {
            return await _DoctorDay.OrderByDescending(a => a.DoctorId==doctorid).ToListAsync();
        }

        public async Task<List<DoctorDays>> GetAllDoctorDaysFromToday(int doctorid)
        {
            //string formattedDate = DateTime.Now.ToString(CultureInfo.CreateSpecificCulture("en-GB"));
            DateTime nowdate = DateTime.Now;
            DateTime changedata=new DateTime(nowdate.Year, nowdate.Month, nowdate.Day, 0, 0, 0);
            return await _DoctorDay.Where(a => a.DoctorId == doctorid && a.ReserveEnglishDatetime >= changedata).ToListAsync();
        }

        public async Task<List<TimeVisitDoctorWebService>> GetAllTimeForWebService(int doctorid)
        {
            List<TimeVisitDoctorWebService> alltimes = new List<TimeVisitDoctorWebService>();
            DateTime nowdate = DateTime.Now;
            DateTime changedata = new DateTime(nowdate.Year, nowdate.Month, nowdate.Day, 0, 0, 0);
            var find= await _DoctorDay.Where(a => a.DoctorId == doctorid && a.ReserveEnglishDatetime >= changedata).ToListAsync();
            foreach (var item in find)
            {
                TimeVisitDoctorWebService newtime = new TimeVisitDoctorWebService();
                newtime.Date = item.ReservePersianDatetime;
                newtime.EnglishDate = item.ReserveEnglishDatetime.ToString();
                newtime.Id = item.Id;
                newtime.CountNobat = item.CountVisit;
                newtime.Description = item.TimeVisit;
                alltimes.Add(newtime);
            }
            return alltimes;
        }
    }
}
