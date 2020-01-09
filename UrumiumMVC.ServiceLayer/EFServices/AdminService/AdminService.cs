using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Admin;
using UrumiumMVC.ServiceLayer.Contract.AdminInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.AdminService
{
    public class AdminService:IAdminService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Admin> _Admin;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public AdminService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Admin = _unitOfWork.Set<Admin>();
        }
        public async Task<bool> AddAdmin(string Name, Boolean AccessDoctor, Boolean AccessIllness, Boolean AccessJudge, Boolean AccessCommon, Boolean AccessAccount, Boolean AccessMedicine, Boolean AccessPharmacy, Boolean AccessUser, Boolean AccessAdmin,string Userid)
        {
            try
            {
                _Admin.Add(new Admin()
                {
                    Name = Name,
                    AccountManagment=AccessAccount,
                    AdminManagment=AccessAdmin,
                    CommonManagment=AccessCommon,
                    DoctorManagment=AccessDoctor,
                    IllnessManagment=AccessIllness,
                    JudgeManagment=AccessJudge,
                    MedicineManagment=AccessMedicine,
                    PharmacyManagment=AccessPharmacy,
                    UserManagment=AccessUser,
                    UserId=Userid
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAdmin(int id)
        {
            var find = await _Admin.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _Admin.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Admin>> GetAllAdmin()
        {
            return await _Admin.OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<Admin> GetAdmin(string userid)
        {
            return await _Admin.Where(a=>a.UserId==userid).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAdmin(int id, string Name, Boolean AccessDoctor, Boolean AccessIllness, Boolean AccessJudge, Boolean AccessCommon, Boolean AccessAccount, Boolean AccessMedicine, Boolean AccessPharmacy, Boolean AccessUser, Boolean AccessAdmin)
        {
            var findadmin = await _Admin.FirstOrDefaultAsync(a => a.Id == id);
            if (findadmin != null)
            {

                findadmin.Name = Name;
                findadmin.AccountManagment = AccessAccount;
                findadmin.AdminManagment = AccessAdmin;
                findadmin.CommonManagment = AccessCommon;
                findadmin.DoctorManagment = AccessDoctor;
                findadmin.IllnessManagment = AccessIllness;
                findadmin.JudgeManagment = AccessJudge;
                findadmin.MedicineManagment = AccessMedicine;
                findadmin.PharmacyManagment = AccessPharmacy;
                findadmin.UserManagment = AccessUser;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
