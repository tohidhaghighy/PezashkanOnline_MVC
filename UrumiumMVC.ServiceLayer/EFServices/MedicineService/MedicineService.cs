using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Medicine;
using UrumiumMVC.ServiceLayer.Contract.MedicineInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.MedicineService
{
    public class MedicineService:IMedicineService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Medicine> _Medicine;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public MedicineService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Medicine = _unitOfWork.Set<Medicine>();
        }

        public async Task<bool> AddMedicine(int id, string Name, string Description)
        {
            try
            {
                _Medicine.Add(new Medicine()
                {
                    Description=Description,
                    Name=Name,
                    PublicMedicine=true,
                    DoctorId=id
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMedicine(int id)
        {
            var find = await _Medicine.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _Medicine.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Medicine>> GetAllMedicine(int doctorid)
        {
            return await _Medicine.Where(b=>b.DoctorId==doctorid).OrderByDescending(a=>a.Id).ToListAsync();
        }

        public async Task<bool> UpdateMedicine(int MedicineId, string Name, string Description, Boolean PublicMedicine)
        {
            try
            {
                var finditem = await _Medicine.FirstOrDefaultAsync(a => a.Id == MedicineId);
                finditem.Name = Name;
                finditem.Description = Description;
                finditem.PublicMedicine = PublicMedicine;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Medicine>> SearchMedicine(int id,string text)
        {
            return await _Medicine.Where(a=>a.DoctorId==id && (a.Name.Contains(text) || a.Description.Contains(text))).ToListAsync();
        }


        public async Task<List<Medicine>> SearchMedicineWebService(string text,int doctorid)
        {
            return await _Medicine.Where(b => b.Name.Contains(text) && b.DoctorId==doctorid).OrderByDescending(a => a.Id).ToListAsync();
        }
    }
}
