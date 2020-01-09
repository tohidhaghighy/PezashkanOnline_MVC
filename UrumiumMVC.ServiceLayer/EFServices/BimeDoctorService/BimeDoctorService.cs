using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Insurance;
using UrumiumMVC.ServiceLayer.Contract.BimeDoctorInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.BimeDoctorService
{
    public class BimeDoctorService: IBimeDoctorService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<InsuranceDoctor> _InsuranceDoctor;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public BimeDoctorService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _InsuranceDoctor = _unitOfWork.Set<InsuranceDoctor>();
        }
        public async Task<bool> AddInsuranceDoctor(int doctorid,int bimeid)
        {
            try
            {
                _InsuranceDoctor.Add(new InsuranceDoctor()
                {
                    DoctorId=doctorid,
                    InsuranceId=bimeid
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteInsuranceDoctor(int id)
        {
            var find = await _InsuranceDoctor.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _InsuranceDoctor.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<InsuranceDoctor>> GetAllInsuranceDoctor(int doctorid)
        {
            return await _InsuranceDoctor.Where(a=>a.DoctorId==doctorid).ToListAsync();
        }
    }
}
