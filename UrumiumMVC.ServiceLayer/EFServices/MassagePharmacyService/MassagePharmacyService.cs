using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;
using UrumiumMVC.ServiceLayer.Contract.MassagePharmacyInterface;
using UrumiumMVC.ViewModel.EntityViewModel.PharmacyViewModel;

namespace UrumiumMVC.ServiceLayer.EFServices.MassagePharmacyService
{
    public class MassagePharmacyService:IMassagePharmacyService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Pharmacy_Massage> _Pharmacy_Massage;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;
        #endregion
        public MassagePharmacyService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Pharmacy_Massage = _unitOfWork.Set<Pharmacy_Massage>();
        }

        public async Task<Boolean> AddPharmacyMassage(int visitid,int pharmacyid,int doctorid,int illnessid,string massage)
        {
            try
            {
                _Pharmacy_Massage.Add(new Pharmacy_Massage()
                {
                    DateOfDescription = DateTime.Now,
                    Description = massage,
                    DoctorId = doctorid,
                    IllnessId = illnessid,
                    PharmacyId = pharmacyid,
                    VisitId = visitid
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public async Task<List<Pharmacy_Massage>> GetPharmacyNoskheMassageToIllness(int illnessid)
        {
            return await _Pharmacy_Massage.Where(a => a.IllnessId == illnessid).ToListAsync();
        }

        public async Task<List<Pharmacy_Massage>> GetPharmacyNoskheMassageToPharmacy(int pharmacyid)
        {
            return await _Pharmacy_Massage.Where(a => a.PharmacyId == pharmacyid).ToListAsync();
        }


        //web service android functions 
        public async Task<List<PharmacyWebService>> GetPharmacyWebSeriveListVisit(int illnessid)
        {
            var find= await _Pharmacy_Massage.Where(a => a.IllnessId == illnessid).ToListAsync();
            List<PharmacyWebService> allpharmacylist = new List<PharmacyWebService>();
            foreach (var item in find)
            {
                PharmacyWebService newpharmacymassage = new PharmacyWebService()
                {
                    Id=item.Id,
                    DateOfDescription=item.DateOfDescription,
                    Description=item.Description,
                    Doctorid=item.DoctorId,
                    Pharmacyname=item.Pharmacies.Name,
                    IllnessId=item.IllnessId,
                    PharmacyId=item.IllnessId,
                    VisitId=item.VisitId
                };
                allpharmacylist.Add(newpharmacymassage);
            }
            return allpharmacylist;
        }


    }
}
