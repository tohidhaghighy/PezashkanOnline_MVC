using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.ServiceLayer.Contract.TimeDateDrInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.TimeDayDrService
{
    public class TimeDayDrService: ITimeDayDrService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<DoctorDays> _DoctorDays;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public TimeDayDrService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _DoctorDays = _unitOfWork.Set<DoctorDays>();
        }

        public async Task<bool> AddDoctorDays(int doctorid, int dayid, string description, int countvisit)
        {
            try
            {
                _DoctorDays.Add(new DoctorDays()
                {
                    CountVisit = countvisit,
                    DayId = dayid,
                    DoctorId = doctorid,
                    TimeVisit = description
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
            var find = await _DoctorDays.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _DoctorDays.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<DoctorDays>> GetAllDoctorDays()
        {
            return await _DoctorDays.ToListAsync();
        }


        public async Task<List<DoctorDays>> GetAllDoctorSelectDays(int doctorid)
        {
            return await _DoctorDays.Where(a => a.DoctorId == doctorid).ToListAsync();
        }
    }
}
