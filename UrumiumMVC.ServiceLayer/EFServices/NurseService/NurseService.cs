using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Nurse;
using UrumiumMVC.ServiceLayer.Contract.NurseInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.NurseService
{
    public class NurseService:INurseService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Nurse> _nurse;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public NurseService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _nurse = _unitOfWork.Set<Nurse>();
        }
        Random rand = new Random();
        public string GetRandomString(int length)
        {
            string s = "";
            for (int i = 0; i < length; i++)
                s += rand.Next(0, 10);
            return s;
        }

        public async Task<bool> AddNurse(string name,string mobile,string password,int cityid)
        {
            try
            {
                _nurse.Add(new Nurse()
                {
                    Active = true,
                    CityId = cityid,
                    Name = name,
                    Is_Use_CodeValue = false,
                    Mobile=mobile,
                    Userid=mobile,
                    Password=password,
                    CodeActiveUse=GetRandomString(6),
                    Image=""
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Boolean> Changepassword(string mobile, string pass, string newpassword)
        {
            var find = await _nurse.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == pass);
            if (find != null)
            {
                find.Password = newpassword;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CheckLogin(string mobile, string password)
        {
            var find = await _nurse.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == password);
            if (find != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> GetNursewithmobile(string mobile)
        {
            var find = await _nurse.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Nurse> GetNurseInfowithmobile(string mobile)
        {
            return await _nurse.FirstOrDefaultAsync(a => a.Mobile == mobile);
        }
    }
}
