using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.DoctorService
{
    public class DoctorNoteService:IDoctorNoteService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<DoctorSubsetPassage> _DoctorSubsetPassage;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public DoctorNoteService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _DoctorSubsetPassage = _unitOfWork.Set<DoctorSubsetPassage>();
        }

        public async Task<bool> AddDoctorSubsetPassage(string text,int doctorid)
        {
            try
            {
                _DoctorSubsetPassage.Add(new DoctorSubsetPassage()
                {
                   Text=text,
                   DoctorId=doctorid
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteDoctorSubsetPassage(int id)
        {
            var find = await _DoctorSubsetPassage.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _DoctorSubsetPassage.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<DoctorSubsetPassage>> GetAllDoctorSubsetPassage(int doctorid)
        {
            return await _DoctorSubsetPassage.Where(a=>a.DoctorId==doctorid).ToListAsync();
        }
    }
}
