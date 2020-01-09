using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Nurse;

namespace UrumiumMVC.ServiceLayer.Contract.NurseInterface
{
    public interface INurseService
    {
        Task<bool> AddNurse(string name, string mobile, string password, int cityid);
        Task<bool> CheckLogin(string mobile, string password);
        Task<bool> GetNursewithmobile(string mobile);
        Task<Nurse> GetNurseInfowithmobile(string mobile);
        Task<Boolean> Changepassword(string mobile, string pass, string newpassword);
    }
}
