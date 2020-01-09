using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Admin;

namespace UrumiumMVC.ServiceLayer.Contract.AdminInterface
{
    public interface IAdminService
    {
        Task<bool> AddAdmin(string Name, Boolean AccessDoctor, Boolean AccessIllness, Boolean AccessJudge, Boolean AccessCommon, Boolean AccessAccount, Boolean AccessMedicine, Boolean AccessPharmacy, Boolean AccessUser, Boolean AccessAdmin, string Userid);
        Task<bool> DeleteAdmin(int id);
        Task<List<Admin>> GetAllAdmin();
        Task<Admin> GetAdmin(string userid);
        Task<bool> UpdateAdmin(int id, string Name, Boolean AccessDoctor, Boolean AccessIllness, Boolean AccessJudge, Boolean AccessCommon, Boolean AccessAccount, Boolean AccessMedicine, Boolean AccessPharmacy, Boolean AccessUser, Boolean AccessAdmin);
    }
}
