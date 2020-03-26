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
    public class PharmacyIllnessMassageService: IPharmacyIllnessService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Illness_Pharmacy_Massage> _IllnessPharmacymassage;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public PharmacyIllnessMassageService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _IllnessPharmacymassage = _unitOfWork.Set<Illness_Pharmacy_Massage>();
        }

        public async Task<bool> AddAnswer(string text, int id)
        {
            var find = await _IllnessPharmacymassage.FirstOrDefaultAsync(a => a.Id == id);
            if (find!=null)
            {
                find.Answer = text;
                find.Exist_Noskhe = true;
                return true;
            }
            return false;
        }

        public async Task<bool> AddPharmacyIllness(Illness_Pharmacy_Massage item)
        {
            if (item!=null)
            {
                _IllnessPharmacymassage.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Illness_Pharmacy_Massage>> GetAll()
        {
            return await _IllnessPharmacymassage.Where(a=>a.Answer!="").OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<IEnumerable<Illness_Pharmacy_Massage>> GetAllIllness(int illnessid)
        {
            return await _IllnessPharmacymassage.Where(a => a.IllnessId == illnessid).OrderByDescending(a => a.Id).ToListAsync();
        }
    }
}
