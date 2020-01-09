using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Violation;
using UrumiumMVC.DomainClasses.Entities.Visit;
using UrumiumMVC.ServiceLayer.Contract.ViolationInterface;
using UrumiumMVC.ViewModel.EntityViewModel.ViolationViewModel;

namespace UrumiumMVC.ServiceLayer.EFServices.ViolationService
{
    public class ViolationService:IViolationService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Violation> _Violation;
        private readonly IDbSet<VisitTime> _VisitTime;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public ViolationService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Violation = _unitOfWork.Set<Violation>();
            _VisitTime = _unitOfWork.Set<VisitTime>();
        }

        public async Task<bool> AddViolation(string number,string userid,string description,int type,string doctorid)
        {
            try
            {
                _Violation.Add(new Violation()
                {
                    Description=description,
                    DoctorId=doctorid,
                    Number=number,
                    Type=type,
                    UserId=userid,
                    CheckIsOk=false,
                    DesAdmin=""
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Violation>> ListViolation()
        {
            
            return await _Violation.OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<List<Violation>> GetViolation(string number)
        {
            return await _Violation.Where(a => a.Number.Contains(number)).ToListAsync() ;
        }

        public async Task<bool> ChangeChecktoOk(int id,string text)
        {
            var find= await _Violation.FirstOrDefaultAsync(a=>a.Id==id);
            if (find!=null)
            {
                find.DesAdmin = text;
                find.CheckIsOk = true;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CheckViolationByAdmin(int Id,string des,bool check)
        {
            var find= await _Violation.FirstOrDefaultAsync(a => a.Id==Id);
            if (find!=null)
            {
                find.CheckIsOk = check;
                find.DesAdmin = des;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ViolationViewModel>> ListViolationOnlyNotCheck()
        {
            List<ViolationViewModel> allviolation = new List<ViolationViewModel>();
            var find= await _Violation.Where(a=>a.CheckIsOk==false).OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in find)
            {
                ViolationViewModel violationvm = new ViolationViewModel();
                violationvm.Id = item.Id;
                violationvm.Check = item.CheckIsOk;
                violationvm.Number = item.Number;
                if (item.Type==0)
                {
                    violationvm.TypePm = "عمومی";
                }
                else
                {
                    violationvm.TypePm = "چت روم";
                }
                violationvm.IllnessDescription = item.Description;
                var findvisit = await _VisitTime.FirstOrDefaultAsync(a => a.PeigiriCode == item.Number);
                if (findvisit!=null)
                {
                    violationvm.VisitId = findvisit.Id;
                    violationvm.DoctorId = findvisit.DoctorId;
                    violationvm.IllnessId = findvisit.UserId;
                    violationvm.AdminDescription = true;
                    violationvm.AdminAnswer = item.DesAdmin;
                }
                else
                {
                    violationvm.AdminDescription =false;
                }
                allviolation.Add(violationvm);
            }
            return allviolation;
        }

        public async Task<List<ViolationViewModel>> GetViolationsearch(string number)
        {
            List<ViolationViewModel> allviolation = new List<ViolationViewModel>();
            var find = await _Violation.Where(a => a.Number.Contains(number)).OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in find)
            {
                ViolationViewModel violationvm = new ViolationViewModel();
                violationvm.Id = item.Id;
                violationvm.Check = item.CheckIsOk;
                violationvm.Number = item.Number;
                if (item.Type == 0)
                {
                    violationvm.TypePm = "عمومی";
                }
                else
                {
                    violationvm.TypePm = "چت روم";
                }
                violationvm.IllnessDescription = item.Description;
                var findvisit = await _VisitTime.FirstOrDefaultAsync(a => a.PeigiriCode == item.Number);
                if (findvisit != null)
                {
                    violationvm.VisitId = findvisit.Id;
                    violationvm.DoctorId = findvisit.DoctorId;
                    violationvm.IllnessId = findvisit.UserId;
                    violationvm.AdminDescription = true;
                    violationvm.AdminAnswer = item.DesAdmin;
                }
                else
                {
                    violationvm.AdminDescription = false;
                }
                allviolation.Add(violationvm);
            }
            return allviolation;
        }


        public async Task<List<ViolationViewModel>> GetViolationuserwithanswer(string userid)
        {
            List<ViolationViewModel> allviolation = new List<ViolationViewModel>();
            var find = await _Violation.Where(a => a.UserId==userid).OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in find)
            {
                ViolationViewModel violationvm = new ViolationViewModel();
                violationvm.Id = item.Id;
                violationvm.Check = item.CheckIsOk;
                violationvm.Number = item.Number;
                if (item.Type == 0)
                {
                    violationvm.TypePm = "عمومی";
                }
                else
                {
                    violationvm.TypePm = "چت روم";
                }
                violationvm.IllnessDescription = item.Description;
                var findvisit = await _VisitTime.FirstOrDefaultAsync(a => a.PeigiriCode == item.Number);
                if (findvisit != null)
                {
                    violationvm.VisitId = findvisit.Id;
                    violationvm.DoctorId = findvisit.DoctorId;
                    violationvm.IllnessId = findvisit.UserId;
                    violationvm.AdminDescription = true;
                    violationvm.AdminAnswer = item.DesAdmin;
                }
                else
                {
                    violationvm.AdminDescription = false;
                }
                allviolation.Add(violationvm);
            }
            return allviolation;
        }
    }
}
