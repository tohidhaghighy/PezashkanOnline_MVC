using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.PharmacyService
{
    public class Pharmacy_MassageService: IPharmacy_MassageService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Pharmacy_Massage> _Pharmacymassage;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public Pharmacy_MassageService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Pharmacymassage = _unitOfWork.Set<Pharmacy_Massage>();
        }

        public async Task<bool> AddPharmacy(string description,int illnessid,int doctorid,int pharmacyid,int visitid)
        {
            var find = await _Pharmacymassage.Where(a => a.VisitId == visitid).ToListAsync();
            if (find.Count()==0)
            {
                _Pharmacymassage.Add(new Pharmacy_Massage()
                {
                    Description = description,
                    DoctorId = doctorid,
                    IllnessId = illnessid,
                    PharmacyId = pharmacyid,
                    VisitId = visitid,
                    DateOfDescription = DateTime.Now
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Pharmacy_Massage>> GetIllnessPharmacyMassage(int Illnessid)
        {
            return await _Pharmacymassage.Where(b=>b.IllnessId==Illnessid).OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<List<Pharmacy_Massage>> GetVisitPharmacyMassage(int visitid)
        {
            return await _Pharmacymassage.Where(b => b.VisitId == visitid).OrderByDescending(a => a.Id).ToListAsync();
        }
    }
}
