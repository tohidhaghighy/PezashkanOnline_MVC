using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Insurance;
using UrumiumMVC.ServiceLayer.Contract.BimeInterface;
using UrumiumMVC.ViewModel.EntityViewModel.InsuranceViewModel;

namespace UrumiumMVC.ServiceLayer.EFServices.BimeService
{
    public class BimeService : IBimeService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Insurance> _Insurance;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public BimeService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Insurance = _unitOfWork.Set<Insurance>();
        }
        public async Task<bool> AddInsurance(string Name, string Description, string Image)
        {
            try
            {
                _Insurance.Add(new Insurance()
                {
                    Description = Description,
                    Image = Image,
                    Name = Name
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteInsurance(int id)
        {
            var find = await _Insurance.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _Insurance.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Insurance>> GetAllInsurance()
        {
            return await _Insurance.OrderByDescending(a => a.Id).ToListAsync();
        }


        public async Task<List<InsuranceWithOutForegnkey>> GetAllInsuranceWebservice()
        {
            List<InsuranceWithOutForegnkey> allinsurance = new List<InsuranceWithOutForegnkey>();
            var find= await _Insurance.OrderByDescending(a => a.Id).ToListAsync();
            if (find!=null)
            {
                foreach (var item in find)
                {
                    InsuranceWithOutForegnkey newinsurance = new InsuranceWithOutForegnkey();
                    newinsurance.Id = item.Id;
                    newinsurance.Image = item.Image;
                    newinsurance.Name = item.Name;
                    newinsurance.Description = item.Description;
                    allinsurance.Add(newinsurance);
                }
            }
            return allinsurance;
        }


        public async Task<Insurance> GetFirstInsurance()
        {
            return await _Insurance.FirstOrDefaultAsync();
        }

        public async Task<List<Insurance>> SearchInsurance(string text)
        {
            return await _Insurance.Where(a => a.Name.Contains(text) || a.Description.Contains(text)).OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<bool> UpdateInsurance(int id, string Name, string Description, string Image)
        {
            var findpharmacy = await _Insurance.FirstOrDefaultAsync(a => a.Id == id);
            if (findpharmacy != null)
            {

                findpharmacy.Name = Name;
                findpharmacy.Description = Description;
                if (Image != "" && Image != null)
                {
                    findpharmacy.Image = Image;
                }
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
